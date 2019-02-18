<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);


$nome;
$password;

if($_SERVER['REQUEST_METHOD'] == "POST")
{
  //$username = $_POST["username"];
  echo $username;
  echo " is your username";
} 
else 
{
  $username = null;
  echo "no username supplied";
}

if($_SERVER['REQUEST_METHOD'] == "POST")
{
  $nome = $_POST["nome"];
  echo $nome;
  echo " is your nome";
} 
else 
{
  $nome = null;
  echo "no nome supplied";
}

if($_SERVER['REQUEST_METHOD'] == "POST")
{
  $password = $_POST["password"];
  echo $password;
  echo " is your password";
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
    echo "php response"
?>