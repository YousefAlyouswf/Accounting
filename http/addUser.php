<?php
include 'db.php';

$userNumber = $_GET['userNumber'];
$password = $_GET['password'];
$position = $_GET['position'];
$userName = $_GET['name'];


if($userNumber != null){
    $result = mysqli_query($conn, "INSERT INTO `users`(`number`,`password`,`position`,`name`)
VALUES('$userNumber','$password','$position','$userName')");
}

$valid = $_GET['valid'];

if($valid != null){


    $query = mysqli_query($conn, "SELECT * from `users` where number='$valid'");

    if (mysqli_num_rows($query) > 0) {
        echo "error";
    }
}
