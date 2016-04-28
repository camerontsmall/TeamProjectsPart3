<?php

$serverName = "co-web-1.lboro.ac.uk"; //co-web-1.lboro.ac.uk
$connectionInfo = array( "Database"=>"team15", "UID"=>"team15", "PWD"=>"U6vn2h4!n");
$conn = sqlsrv_connect( $serverName, $connectionInfo);

if( !$conn ) {
     echo "Connection could not be established.<br />";
     die( print_r( sqlsrv_errors(), true));
}