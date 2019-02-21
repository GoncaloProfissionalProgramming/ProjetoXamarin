<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);

    $statement = mysqli_prepare($con, "SELECT * FROM notas WHERE id = ?" );
    mysqli_stmt_bind_param($statement, "s",$id);
    mysqli_stmt_execute($statement);
    mysqli_stmt_store_result($statement);
    mysqli_stmt_bind_result($statement,$id,$nota,$turmaId,$disciplina,$nomeAluno,$extenso);
    $response = array();
    $response["success"] = false;
    while(mysqli_stmt_fetch($statement)){
        $response["success"] = true;
        $response["id"] = $id;
		$response["nota"] = $nota;
		$response["turmaId"] = $turmaId;
        $response["disciplina"] = $disciplina;
	    $response["nomeAluno"] = $nomeAluno;
		$response["extenso"] = $extenso;

       
       
      }
    echo json_encode($response);
?>