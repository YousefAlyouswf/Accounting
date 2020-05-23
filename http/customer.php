<?php
include 'db.php';


$person = $_GET['person'];
$phone = $_GET['phone'];
$mobile = $_GET['mobile'];
$fax = $_GET['fax'];
$address = $_GET['address'];
$city = $_GET['city'];
$email = $_GET['email'];
$web = $_GET['web'];

if($person != null){
    $result = mysqli_query($conn , "INSERT INTO `costumer`(`costumerName`, `phone`, `mobile`, `fax`, `address`, `city`, `email`, `site`) 
VALUES ('$person','$phone','$mobile','$fax','$address','$city','$email','$web')");
}
$valid = $_GET['valid'];

if($valid != null){
    $query = mysqli_query($conn, "SELECT * from `costumer` where costumerName='$valid'");

    if (mysqli_num_rows($query) > 0) {
        echo "error";
    }
}

$dropBox=$_GET['dropbox'];
if($dropBox != null){

    $query = mysqli_query($conn, "SELECT costumerName from `costumer` ORDER BY costumerName");

    while ($result = mysqli_fetch_array($query)) {
        $costumerName = $result['costumerName'];


        echo $costumerName;
        echo '|';
    }
}
$auth = $_GET['auth'];
if($auth != null){
    $query = mysqli_query($conn, "SELECT * from `costumer`");

    while ($result = mysqli_fetch_array($query)) {

        $name = $result['costumerName'];
        $phone = $result['phone'];
        $mobile = $result['mobile'];
        $fax = $result['fax'];
        $address = $result['address'];
        $city = $result['city'];
        $email = $result['email'];
        $web = $result['site'];

        echo $name;
        echo ',';
        echo $mobile;
        echo ',';
        echo $phone;
        echo ',';
        echo $fax;
        echo ',';
        echo $address;
        echo ',';
        echo $city;
        echo ',';
        echo $email;
        echo ',';
        echo $web;
        echo '|';
    }
}