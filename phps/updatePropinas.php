﻿<?php
require_once "connection.php";
require_once "var.php";
$con = new mysqli(DB_HOST, DB_USER, DB_PASSWORD, DB_DATABASE);

$statement = mysqli_prepare($con, "UPDATE propinas SET  pagoN = ?  WHERE id=?");
mysqli_stmt_bind_param($statement, "ss",$pagoN,$id);
mysqli_stmt_execute($statement);
mysqli_stmt_store_result($statement);
echo json_encode("php response");

?>