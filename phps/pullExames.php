<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);

    $statement = mysqli_prepare($con, "SELECT * FROM exames WHERE turmaId = ? ");
    mysqli_stmt_bind_param($statement, "sssss",$dia,$inicio,$fim,$profId,$turmaId);
    mysqli_stmt_execute($statement);
    mysqli_stmt_store_result($statement);
    mysqli_stmt_bind_result($statement, $dia,$inicio,$fim,$profId,$turmaId);
    $response = array();
    $response["success"] = false;
    while(mysqli_stmt_fetch($statement)){
        $response["success"] = true;
        $response["turmaId"] = $turmaId;
		$response["dia"] = $dia;
        $response["inicio"] = $inicio;
        $response["fim"] = $fim;
        $response["profId"] = $profId;
        
       
      }
    echo json_encode($response);
?>