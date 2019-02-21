<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);

 $statement = mysqli_prepare($con, "SELECT disciplina FROM horario ORDER by id" );
 
 $count = 0;

 
  mysqli_stmt_execute($statement);
 
 while (mysqli_stmt_fetch($statement)) {
        $count ++;
    }


echo $count;
?>