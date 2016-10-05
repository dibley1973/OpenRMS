require 'puppet/provider/package'

Puppet::Type.type(:package).provide :npm, :parent => Puppet::Provider::Package do
  desc "npm package manager for node.js"

  has_feature :installable, :uninstallable, :upgradeable, :versionable, :install_options

  ## query() will set this on first run as we may determine it from install_option nodepath
  attr_accessor :npm_cmd
  
  ## noop, as we may not find out npm location until instatiated
  def self.instances
    []
  end

  ## get dir where node executable is installed, from nodepath property, or PATH,
  ## then return robust way to run npm
  def build_npm_cmd
    options = install_options
    nodepath = options[:nodepath] || ((node = which 'node') && File.dirname(node))
    raise Puppet::Error, "failed to find node.js, set 'nodepath' property or PATH" unless nodepath
    "#{nodepath}/npm"
  end

  #stuff added to try and make install options work with puppet 3
  def install_options
    collect_options(resource[:install_options])
  end

  def collect_options(options)
    return unless options
    newOpts = Hash.new
    options.each do |val|
      case val
      when Hash
        val.keys.each do |key|
          newOpts[key] = val[key]
        end
      else
        newOpts[val] = val
      end
    end

    symbolizehash(newOpts)
  end
  
  ## can exec for global, or cd to a dir and run local installation
  def npm_exec(args)
    options = symbolizehash(@resource[:install_options] || {})
    scope = (options[:global] == false) ? "local" : "global"
    cwd = options[:cwd] ? "cd #{options[:cwd]}&&" : ""

    command = "#{cwd} #{@npm_cmd} --#{scope} #{args}"
    self.debug "running npm as: #{command}"

    begin
      execute command
    rescue Puppet::ExecutionFailure => e
      raise Puppet::Error, "failed to exec npm as '#{command}'}: #{e}"
    end

  end

  ## run npm list command and return an array pkgs as hashes {:name,:version}
  ## return single hash (or nil) for matching pkg if name given as arg
  def npm_list(pkgname = nil)
    output = npm_exec "list --long --parseable"
    packages = output.split("\n").grep(/([\w-]+)@([\d\.]+)/) { {:name => $1, :version => $2} }

    if pkgname
      packages.select {|p| p[:name] == pkgname}.first
    else
      packages
    end

  end

  def install
    should = @resource.should(:ensure)
    self.debug "ensuring => #{should}"

    ## set to nil unless version given
    case should
    when true, false, Symbol
      should = nil
    end

    ## name of pkg to install, with version appended if requested
    pkgname = @resource[:name].to_s + (should ? "@#{should}" : '')

    begin
      npm_exec "install #{pkgname}"
    rescue Puppet::ExecutionFailure => e
      raise Puppet::Error, "failed to install package #{pkgname}: #{e}"
    end

    ## check package was installed
    installed = self.query
    raise Puppet::Error, "failed to find package #{pkgname}" unless installed
  end
  
  ## return latest version available
  def latest
    output = npm_exec "view #{@resource[:name]} versions"
    output.split(/[^\d\.]+/).last
  end

  def update
    self.install
  end

  def uninstall
    npm_exec "uninstall #{resource[:name]}"
  end

  ## this should get run before install or uninstall
  def query

    ## set this on first run
    @npm_cmd = build_npm_cmd unless @npm_cmd

    package = npm_list(@resource[:name])

    if package
      { :name => @resource[:name], :ensure => package[:version] }
    else
      { :name => @resource[:name], :ensure => :purged, :status => 'missing' }
    end
  end
    
end
