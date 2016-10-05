class profiles::openrms-db {
  class { 'postgresql::server':
    ip_mask_deny_postgres_user => '0.0.0.0/32',
    ip_mask_allow_all_users    => '0.0.0.0/0',
    listen_addresses           => '*',
    postgres_password          => 'password',
  }

  postgresql::server::db { 'openrms':
    user     => 'openrms',
    password => postgresql_password('openrms', 'password'),
  }

  postgresql::server::db { 'security':
    user     => 'openrms',
    password => postgresql_password('openrms', 'password'),
  }
}