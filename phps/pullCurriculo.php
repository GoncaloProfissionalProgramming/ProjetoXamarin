<?php
require_once "connection.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);



if($_SERVER['REQUEST_METHOD'] == "POST")
{
  $sql = "SELECT id FROM aluno where username=$_POST["username"]";
  $statement = mysqli_prepare($con,$sql, "SELECT telemovel,morada,email FROM curriculo  where aluno.id=curriculo.id");
} 
else 
{
  $username = null;
  echo "no username supplied";
}

    mysqli_stmt_bind_param($statement, "sss");
    mysqli_stmt_execute($statement);
    mysqli_stmt_close($statement);
    echo "php response"
?>