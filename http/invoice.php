<?php
include 'db.php';



$discount = $_GET['discount'];
$tax = $_GET['tax'];
$note = $_GET['note'];
$id = $_GET['id'];
$supplier = $_GET['supplier'];
$dateGet = $_GET['date'];
$date = date("Y-m-d",strtotime($dateGet));
if($dateGet != null){

    $result = mysqli_query($conn , "INSERT INTO `invoice`(`date`, `discount`, `tax`, `note`, `inv_id`, `supplier_id`) 
VALUES ('$date','$discount','$tax','$note','$id','$supplier')");
}

$auth = $_GET['auth'];
if($auth != null){
    $query = mysqli_query($conn, "SELECT * from `invoice`");

    while ($result = mysqli_fetch_array($query)) {

        $date = $result['date'];
        $discount = $result['discount'];
        $tax = $result['tax'];
        $note= $result['note'];
        $inv_id = $result['inv_id'];
        $supplier_id = $result['supplier_id'];


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
        echo $supplier_id;

        echo '|';
    }
}