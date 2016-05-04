<?php
ini_set("display_errors",1);
error_reporting(E_ALL);


require('../connect.php');



$array = array();

if(isset($_GET['type']) && $_GET['park']){
	$type = $_GET['type'];
	$park =  $_GET['park'];
}


if(isset($type) && isset($park)){
	$query = "SELECT * FROM room WHERE type = '$type' AND park = '$park';";
}else{
	$query = "SELECT * FROM room;";
}
	
if($result = sqlsrv_query($conn, $query)){
    while($row = sqlsrv_fetch_array($result, SQLSRV_FETCH_ASSOC)){
        $array[] = $row;
    }
    echo json_encode($array);
}else{
    return false;
}
