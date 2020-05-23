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

if($company != null){
    $result = mysqli_query($conn , "INSERT INTO `suppliers`(`companyName`, `person`, `phone`, `mobile`, `fax`, `address`, `city`, `email`, `site`) 
VALUES ('$company','$person','$phone','$mobile','$fax','$address','$city','$email','$web')");
}

$valid=$_GET['valid'];
if($valid != null){
    $query = mysqli_query($conn, "SELECT * from `suppliers` where companyName='$valid'");

    if (mysqli_num_rows($query) > 0) {
        echo "error";
    }
}


$dropBox=$_GET['dropbox'];
if($dropBox != null){

    $query = mysqli_query($conn, "SELECT * from `suppliers` ORDER BY companyName");

    while ($result = mysqli_fetch_array($query)) {
        $companyName = $result['companyName'];


        echo $companyName;
        echo '|';
    }
}
$auth = $_GET['auth'];
if($auth != null){
    $query = mysqli_query($conn, "SELECT * from `suppliers`");

    while ($result = mysqli_fetch_array($query)) {

        $company1 = $result['companyName'];
        $name = $result['person'];
        $phone = $result['phone'];
        $mobile = $result['mobile'];
        $fax = $result['fax'];
        $address = $result['address'];
        $city = $result['city'];
        $email = $result['email'];
        $web = $result['site'];

        echo $company1;
        echo ',';
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