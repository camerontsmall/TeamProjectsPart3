<?php

require('../connect.php');

$array = array();
if($result = sqlsrv_query($conn, "SELECT * FROM submissions;")){
    while($row = sqlsrv_fetch_array($result)){
        $array[] = $row;
    }
    echo json_encode($array);
}else{
    return false;
}
