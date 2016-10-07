class profiles::openrms-db {
  # Configure server
  class { 'postgresql::server':
    ip_mask_deny_postgres_user => '0.0.0.0/32',
    ip_mask_allow_all_users    => '0.0.0.0/0',
    listen_addresses           => '*',
    postgres_password          => 'password',
  }

  # Create db
  postgresql::server::db { 'openrms':
    user => 'openrms',
    password => postgresql_password('openrms', 'password'),
  }
  
  # Install contrib modules
  class { 'postgresql::server::contrib':
	package_ensure => 'present',
  }
  
  # Install extensions
  postgresql::server::extension { 'uuid-ossp':
	database => 'openrms',
	ensure => present,	
  }
}