puppet-npm-simple - Puppet provider for npm packages
====================================================

There are other package providers for npm, but they generally install
a specific version of node.js (either limited to a package system or
an old version).

npm-simple does not install node.js. In fact, it is suitable for
systems where you have multiple versions of node.js installed in
non-standard locations. It is up to you to install node and either
have it in your PATH or tell npm-simple where to find it.
    
Latest version of this code may be found on
[github](http://github.com/rlister/puppet-npm-simple).

Installation
------------

Just drop this package in your Puppet modulepath, e.g.:

    # cd /etc/puppet/modules
    # git clone http://github.com/rlister/puppet-npm-simple

Usage
-----

By default, npm-simple will use node from your path and do a global
npm installation:

    package { "underscore":
      provider => npm,
      ensure   => installed,
    }

As with other package providers, you can ensure 'latest', 'absent', or
specific versions.

If you are using node from a location not in your path, set 'nodepath'
option:
    
    package { "underscore":
      provider        => npm,
      ensure          => installed,
      install_options => {
        nodepath      => "/opt/node-v0.6.16/bin",
      }
    }

To do a local install, in a specific project directory, set option
'global' to false, and give the directory as 'cwd':

    package { "underscore":
      provider        => npm,
      ensure          => installed,
      install_options => {
        nodepath      => "/opt/node-v0.6.16/bin",
        global        => false,
        cwd           => '/u/apps/foobar',
      }
    }

The provider does not impose any specific restrictions on user. It
will run with same permissions as puppet, which is probably what you
want. You are obviously limited by write permissions on the npm
modules installation dir, whether global or local.
