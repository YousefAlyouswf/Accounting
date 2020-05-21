<?php
include 'db.php';


$category = $_GET['category'];
if($category != null){
    $query = mysqli_query($conn, "SELECT * from `category` where categoryName='$category'");

    if (mysqli_num_rows($query) > 0) {
        echo "error";
    } else {
        $result = mysqli_query($conn, "INSERT INTO `category`(`categoryName`)
VALUES('$category')");
    }
}


$auth = $_GET['auth'];

if($auth != null){

    $query = mysqli_query($conn, "SELECT * from `category`");

    while ($result = mysqli_fetch_array($query)) {
        $categoryName = $result['categoryName'];
        $id = $result['id'];


        echo strval($id);
        echo ',';
        echo $categoryName;
        echo '|';
    }
}

$dropBox=$_GET['dropbox'];
if($dropBox != null){

    $query = mysqli_query($conn, "SELECT * from `category` ORDER BY categoryName");

    while ($result = mysqli_fetch_array($query)) {
        $categoryName = $result['categoryName'];


        echo $categoryName;
        echo '|';
    }
}