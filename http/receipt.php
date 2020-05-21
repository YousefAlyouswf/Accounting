<?php
include 'db.php';



$discount = $_GET['discount'];
$tax = $_GET['tax'];
$note = $_GET['note'];
$id = $_GET['id'];
$customer = $_GET['customer'];

$date = date("Y-m-d",strtotime($_GET['date']));
if($date != null){

    $result = mysqli_query($conn , "INSERT INTO `receipt`(`date`, `discount`, `tax`, `note`, `receipt_id`, `custumer_id`) 
VALUES ('$date','$discount','$tax','$note','$id','$customer')");
}