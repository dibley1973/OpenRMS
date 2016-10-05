class dnx (
	$install_user  = $dnx::params::install_user,
	$install_group = $dnx::params::install_group,
	$install_path  = $dnx::params::install_path,
) inherits dnx::params {

	include stdlib
	validate_string($install_user)
	validate_string($install_group)
	validate_string($install_path)
	
	class { 'dnx::install': }
	class { 'dnx::execute':
		require => Class['dnx::install'],
	}
}