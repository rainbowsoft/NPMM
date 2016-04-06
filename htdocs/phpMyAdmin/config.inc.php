<?php
/*
 * This is needed for cookie based authentication to encrypt password in
 * cookie
 */
$cfg['blowfish_secret'] = 'xampp'; /* YOU SHOULD CHANGE THIS FOR A MORE SECURE COOKIE AUTH! */

/*
 * Servers configuration
 */
$i = 0;

/*
 * First server
 */
$i++;

/* Authentication type and info */
$cfg['Servers'][$i]['auth_type'] = 'config';
$cfg['Servers'][$i]['user'] = 'root';
$cfg['Servers'][$i]['password'] = '';
$cfg['Servers'][$i]['extension'] = 'mysqli';
$cfg['Servers'][$i]['AllowNoPassword'] = true;
$cfg['Lang'] = '';

/* Bind to the localhost ipv4 address and tcp */
$cfg['Servers'][$i]['host'] = '127.0.0.1';
$cfg['Servers'][$i]['connect_type'] = 'tcp';

/* User for advanced features */
$cfg['Servers'][$i]['controluser'] = 'pma';
$cfg['Servers'][$i]['controlpass'] = '';

/* Advanced phpMyAdmin features */
$cfg['Servers'][$i]['pma_pmadb'] = 'phpmyadmin';
$cfg['Servers'][$i]['pma_bookmarktable'] = 'pma_bookmark';
$cfg['Servers'][$i]['pma_relation'] = 'pma_relation';
$cfg['Servers'][$i]['pma_table_info'] = 'pma_table_info';
$cfg['Servers'][$i]['pma_table_coords'] = 'pma_table_coords';
$cfg['Servers'][$i]['pma_pdf_pages'] = 'pma_pdf_pages';
$cfg['Servers'][$i]['pma_column_info'] = 'pma_column_info';
$cfg['Servers'][$i]['pma_history'] = 'pma_history';
$cfg['Servers'][$i]['pma_designer_coords'] = 'pma_designer_coords';
$cfg['Servers'][$i]['pma_tracking'] = 'pma_tracking';
$cfg['Servers'][$i]['pma_userconfig'] = 'pma_userconfig';
$cfg['Servers'][$i]['pma_recent'] = 'pma_recent';
$cfg['Servers'][$i]['pma_table_uiprefs'] = 'pma_table_uiprefs';

/*
 * End of servers configuration
 */

?>
