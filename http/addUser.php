<?php
include 'db.php';

$userNumber = $_GET['userNumber'];
$password = $_GET['password'];
$position = $_GET['position'];
$userName = $_GET['name'];

$result = mysqli_query($conn, "INSERT INTO `users`(`number`,`password`,`position`,`name`)
VALUES('$userNumber','$password','$position','$userName')");