<?php
include 'db.php';
$itemName = $_GET['itemName'];
$category = $_GET['category'];
$unit = $_GET['unit'];
$price_buy = $_GET['price_buy'];
$price_sell = $_GET['price_sell'];

if($itemName != null){
    $result = mysqli_query($conn, "INSERT INTO `items`(`itemName`,`category`,`unit`,`price_buy`,`price_sell`)
VALUES('$itemName','$category','$unit','$price_buy','$price_sell')");
}

$auth = $_GET['auth'];

if($auth != null){
    $query = mysqli_query($conn, "SELECT * from `items` ORDER BY category");

    while ($result = mysqli_fetch_array($query)) {

        $date = $result['itemName'];
        $discount = $result['category'];
        $tax = $result['unit'];
        $note = $result['price_buy'];
        $inv_id = $result['price_sell'];


        echo $date;
        echo ',';
        echo $discount;
        echo ',';
        echo $tax;
        echo ',';
        echo $note;
        echo ',';
        echo $inv_id;


        echo '|';
    }
}