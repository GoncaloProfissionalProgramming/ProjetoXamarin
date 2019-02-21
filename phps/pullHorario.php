<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);

    $statement = mysqli_prepare($con, "SELECT * FROM horario WHERE id = ?" );
    mysqli_stmt_bind_param($statement, "s",$id);
    mysqli_stmt_execute($statement);
    mysqli_stmt_store_result($statement);
    mysqli_stmt_bind_result($statement,$id,$turmaId,$sala,$disciplina,$inicio,$fim,$diaDaSemana);
    $response = array();
    $response["success"] = false;
    while(mysqli_stmt_fetch($statement)){
        $response["success"] = true;
        $response["id"] = $id;
		$response["turmaId"] = $turmaId;
        $response["sala"] = $sala;
        $response["disciplina"] = $disciplina;
	    $response["inicio"] = $inicio;
		$response["fim"] = $fim;
		$response["diaDaSemana"] = $diaDaSemana;
       
       
      }
    echo json_encode($response);
?>