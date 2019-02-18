<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);

    $statement = mysqli_prepare($con, "SELECT * FROM propinas WHERE alunoId = ? ");
    mysqli_stmt_bind_param($statement, "sss",$mes,$pagoN,$alunoId);
    mysqli_stmt_execute($statement);
    mysqli_stmt_store_result($statement);
    mysqli_stmt_bind_result($statement, $mes,$pagoN,$alunoId);
    $response = array();
    $response["success"] = false;
    while(mysqli_stmt_fetch($statement)){
        $response["success"] = true;
        $response["alunoId"] = $alunoId;
		$response["mes"] = $mes;
        $response["pagoN"] = $pagoN;
      }
    echo json_encode($response);
?>