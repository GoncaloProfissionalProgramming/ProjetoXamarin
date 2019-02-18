<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);



if($_SERVER['REQUEST_METHOD'] == "POST")
{
  $statement = mysqli_prepare($con, "SELECT telemovel,morada,email FROM curriculo  where aluno.username=$username");
} 
else 
{
  $username = null;
  echo "no username supplied";
}

    mysqli_stmt_bind_param($statement, "sss",$username);
    mysqli_stmt_execute($statement);
    mysqli_stmt_close($statement);
    echo "php response"
?>