﻿<?php
require_once "connection.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);


$nome;
$password;

if($_SERVER['REQUEST_METHOD'] == "POST")
{
  $username = $_POST["username"];
 
} 
else 
{
  $username = null;
  echo "no username supplied";
}

if($_SERVER['REQUEST_METHOD'] == "POST")
{
  $nome = $_POST["nome"];
 
 
} 
else 
{
  $nome = null;
  echo "no nome supplied";
}

if($_SERVER['REQUEST_METHOD'] == "POST")
{
  $password = $_POST["password"];
 
 
} 
else 
{
  $password = null;
  echo "no password supplied";
}
   
    
    $statement = mysqli_prepare($con, "INSERT INTO aluno (nome, username, password) VALUES (?, ?, ?)");
    mysqli_stmt_bind_param($statement, "sss", $nome, $username, $password);
    mysqli_stmt_execute($statement);
    mysqli_stmt_close($statement);
    
    
    $statement = mysqli_prepare($con, "SELECT * FROM aluno WHERE username = ? AND password = ?");
    mysqli_stmt_bind_param($statement, "ss", $username, $password);
    mysqli_stmt_execute($statement);
    mysqli_stmt_store_result($statement);
    mysqli_stmt_bind_result($statement, $id, $nome, $username, $password,$notasId,$turmaId,$curriculoId,$propinasId);
    $response = array();
    $response["success"] = false;
    while(mysqli_stmt_fetch($statement)){
        $response["success"] = true;
        $response["id"] = $id;
        $response["nome"] = $nome;
        $response["username"] = $username;
        $response["password"] = $password;
        $response["notasId"] = $notasId;
        $response["turmaId"] = $turmaId;
        $response["curriculoId"] = $curriculoId;
        $response["propinasId"] = $propinasId;
        
      }
    echo json_encode($response);

?>