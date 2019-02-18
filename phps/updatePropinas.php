<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);

$statement = mysqli_prepare($con, "UPDATE propinas SET mes = ?, pagoN = ?  WHERE alunoId=?");
mysqli_stmt_bind_param($statement, "sss",$mes,$pagoN,$alunoId);
mysqli_stmt_execute($statement);
mysqli_stmt_store_result($statement);
mysqli_stmt_bind_result($statement);
$response = array();
$response["success"] = false;
while(mysqli_stmt_fetch($statement)){
    $response["success"] = true;
      
         $response["mes"] = $mes;
         $response["pagoN"] = $pagoN;
         $response["alunoId"] = $alunoId;
   
   
  }
echo json_encode($response);

?>