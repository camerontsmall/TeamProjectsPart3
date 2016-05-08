<?php

//header('Content-Type: application/json');
require('../connect.php');

$array = array();

$part = $_GET['part'];
$dept = $_GET['dept'];

if(strlen($part) > 0){
	$searching = true;
}else{
	$searching = false;
	}

$query = "SELECT * FROM module WHERE dept_id='$dept';";
	
if($result = sqlsrv_query($conn, $query)){
    while($row = sqlsrv_fetch_array($result, SQLSRV_FETCH_ASSOC)){
        $array[] = $row;
    }
	if($searching){
		foreach($array as $key => $module){
			$partkey = $module["module_code"][2];
			if(strtolower($partkey) != strtolower($part)){ unset($array[$key]); }
		}
	}
	$array = array_values($array);
	echo json_encode($array);
}else{
	echo "{}";
}
