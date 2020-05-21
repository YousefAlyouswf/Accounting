<?php
include 'db.php';


$company = $_GET['company'];
$person = $_GET['person'];
$phone = $_GET['phone'];
$mobile = $_GET['mobile'];
$fax = $_GET['fax'];
$address = $_GET['address'];
$city = $_GET['city'];
$email = $_GET['email'];
$web = $_GET['web'];

    $query = mysqli_query($conn, "SELECT * from `suppliers` where companyName='$company'");

    if (mysqli_num_rows($query) > 0) {
        echo "error";
    } else {
        $result = mysqli_query($conn , "INSERT INTO `suppliers`(`companyName`, `person`, `phone`, `mobile`, `fax`, `address`, `city`, `email`, `site`) 
VALUES ('$company','$person','$phone','$mobile','$fax','$address','$city','$email','$web')");
       
    }
