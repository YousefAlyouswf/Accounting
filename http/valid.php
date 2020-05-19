<?php
include 'db.php';

$userNumber = $_GET['userNumber'];

$query = mysqli_query($conn, "SELECT * from `users` where number='$userNumber'");

if (mysqli_num_rows($query) > 0) {
    echo "error";
}