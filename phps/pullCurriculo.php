<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);

    $statement = mysqli_prepare($con, "SELECT * FROM curriculo WHERE id = ? ");
    mysqli_stmt_bind_param($statement, "s", $id);
    mysqli_stmt_execute($statement);
    mysqli_stmt_store_result($statement);
    mysqli_stmt_bind_result($statement,$id,$telemovel,$morada,$email);
    $response = array();
    $response["success"] = false;
    while(mysqli_stmt_fetch($statement)){
        $response["success"] = true;
        $response["id"] = $id;
		$response["telemovel"] = $telemovel;
        $response["morada"] = $morada;
        $response["email"] = $email;
       
       
      }
    echo json_encode($response);
?>