<?php
include 'db.php';



$discount = $_GET['discount'];
$tax = $_GET['tax'];
$note = $_GET['note'];
$id = $_GET['id'];
$customer = $_GET['customer'];
$dateGet = $_GET['date'];
$date = date("Y-m-d",strtotime($dateGet));
if($dateGet != null){

    $result = mysqli_query($conn , "INSERT INTO `receipt`(`date`, `discount`, `tax`, `note`, `receipt_id`, `custumer_id`) 
VALUES ('$date','$discount','$tax','$note','$id','$customer')");
}
//SELECT * from `receipt` WHERE DATE(date) > '2020-05-15'

$auth = $_GET['auth'];
if($auth != null){
    $query = mysqli_query($conn, "SELECT * from `receipt` ORDER BY date DESC");

    while ($result = mysqli_fetch_array($query)) {

        $date = $result['date'];
        $discount = $result['discount'];
        $tax = $result['tax'];
        $note= $result['note'];
        $inv_id = $result['receipt_id'];
        $customer = $result['custumer_id'];


        echo $date;
        echo ',';
        echo $discount;
        echo ',';
        echo $tax;
        echo ',';
        echo $note;
        echo ',';
        echo $inv_id;
        echo ',';
        echo $customer;

        echo '|';
    }
}