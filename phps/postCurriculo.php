<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);

    $morada = "";
	$telemovel = "";
	$email = "";
    
    $statement = mysqli_prepare($con, "INSERT INTO curriculo (id, telemovel, morada , email) VALUES (?, ?, ?,?)");
    mysqli_stmt_bind_param($statement, "ssss", $id, $morada, $telemovel,$email);
    mysqli_stmt_execute($statement);
    mysqli_stmt_close($statement);
    echo "php response"
?>