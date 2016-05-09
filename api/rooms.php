<?php

require('../connect.php');



$array = array();

if(isset($_GET['type']) && $_GET['park']){
	$type = $_GET['type'];
	$park =  $_GET['park'];
}

$dept_id = $_GET['dept'];

if(isset($type) && isset($park)){
	$query = "SELECT * FROM room WHERE type = '$type' AND park = '$park' AND (dept_id = '' OR dept_id = '$dept_id');";
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
