<?php

require('../connect.php');

error_reporting(E_ERROR | E_PARSE);
$room_code = $_GET['code'];


$query = "SELECT * FROM room WHERE room_code = '$room_code';";
	
if($result = sqlsrv_query($conn, $query)){
    while($row = sqlsrv_fetch_array($result, SQLSRV_FETCH_ASSOC)){
        $result = $row;
    }
    echo json_encode($result);
}else{
    return false;
}
