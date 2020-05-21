<?php
include 'db.php';
$itemName = $_GET['itemName'];
$category = $_GET['category'];
$unit = $_GET['unit'];
$price_buy = $_GET['price_buy'];
$price_sell = $_GET['price_sell'];

$result = mysqli_query($conn, "INSERT INTO `items`(`itemName`,`category`,`unit`,`price_buy`,`price_sell`)
VALUES('$itemName','$category','$unit','$price_buy','$price_sell')");
if(mysqli_query($conn, $result)){
    echo "Records inserted successfully.";
} else{
    echo "ERROR: Could not able to execute $result. " . mysqli_error($conn);
}