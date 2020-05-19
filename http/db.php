<?php

$servername = "db5000467558.hosting-data.io";
$username = "dbu449139";
$password = "Yy147963!";
$port = "3308";
// Create connection
$conn = mysqli_connect($servername, $username, $password,'dbs448025');

// Check connection
if (!$conn) {
    die("Connection failed: " . $conn->connect_error);
}
mysqli_query($conn,"set character_set_server='utf8'");
mysqli_query($conn,"set names 'utf8'");

