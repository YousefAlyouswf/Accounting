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
    $query = mysqli_query($conn, "SELECT * from `costumer` where costumerName='$person'");

    if (mysqli_num_rows($query) > 0) {
        echo "error";
    } else {
        $result = mysqli_query($conn , "INSERT INTO `costumer`(`costumerName`, `phone`, `mobile`, `fax`, `address`, `city`, `email`, `site`) 
VALUES ('$person','$phone','$mobile','$fax','$address','$city','$email','$web')");

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