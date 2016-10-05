class dnx::install inherits dnx {

	# .NET Version Manager (DNVM) prerequsites
	package { 'curl':  ensure => installed }
	package { 'unzip':  ensure => installed }

	# .NET Execution Environment (DNX) prerequsites
	package { 'libunwind8':  ensure => installed }
	package { 'gettext':  ensure => installed }
	package { 'libssl-dev':  ensure => installed } 
	package { 'libcurl4-openssl-dev':  ensure => installed }
	package { 'zlib1g':  ensure => installed }
	package { 'libicu-dev':  ensure => installed }
	package { 'uuid-dev':  ensure => installed } 
	
	# libuv prerequsites
	package { 'make':  ensure => installed }
	package { 'automake':  ensure => installed }
	package { 'libtool':  ensure => installed } 

	# Install Scripts
	file { "dnvm.sh":
		path    => "${install_path}/dnvm.sh",
		owner   => $install_user,
		group   => $install_group,
		mode    => '0755',
		content => template('dnx/dnvm.sh.erb')
	}
	
	file { "install_dnx.sh":
		path    => "${install_path}/install_dnx.sh",
		owner   => $install_user,
		group   => $install_group,
		mode    => '0755',
		content => template('dnx/install_dnx.sh.erb')
	}
	
	file { "$install_path/libuv-1.8.0.tar.gz":
        mode => "0755",
        owner => $install_user,
        group => $install_group,
        source => 'puppet:///modules/dnx/libuv-1.8.0.tar.gz',
    } ~>
		exec { "unpack_libuv":
			command 	=> "tar zxfv ${install_path}/libuv-1.8.0.tar.gz -C /usr/local/src",
			path 		=> $paths,
			provider 	=> 'shell',
			logoutput 	=> 'on_failure',
		} 			
}

class dnx::execute inherits dnx {

	# Execute the .net version manager and install core clr
	exec { "install_dnx":
		command 	=> "${install_path}/install_dnx.sh",
		user 		=> $install_user,
		path 		=> $paths,
		provider 	=> 'shell',
		logoutput 	=> 'on_failure',
	}
	
	exec { "build_libuv":
		command 	=> '/usr/local/src/libuv-1.8.0/build.sh',
		cwd			=> '/usr/local/src/libuv-1.8.0/',
		path 		=> $paths,
		provider 	=> 'shell',
		logoutput 	=> 'on_failure',
	}
	
	
}