<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);

$statement = mysqli_prepare($con, "UPDATE curriculo SET telemovel = ?, morada = ?, email=?  WHERE id=?");
mysqli_stmt_bind_param($statement, "ssss",$telemovel,$morada,$email,$id);
mysqli_stmt_execute($statement);
mysqli_stmt_store_result($statement);
mysqli_stmt_bind_result($statement);
$response = array();
$response["success"] = false;
while(mysqli_stmt_fetch($statement)){
    $response["success"] = true;
      
         $response["telemovel"] = $telemovel;
         $response["morada"] = $morada;
         $response["email"] = $email;
         $response["id"] = $id;
   
   
  }
echo json_encode($response);

?>