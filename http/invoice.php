<?php
include 'db.php';



$discount = $_GET['discount'];
$tax = $_GET['tax'];
$note = $_GET['note'];
$id = $_GET['id'];
$supplier = $_GET['supplier'];

$date = date("Y-m-d",strtotime($_GET['date']));
if($date != null){

    $result = mysqli_query($conn , "INSERT INTO `invoice`(`date`, `discount`, `tax`, `note`, `inv_id`, `supplier_id`) 
VALUES ('$date','$discount','$tax','$note','$id','$supplier')");
}