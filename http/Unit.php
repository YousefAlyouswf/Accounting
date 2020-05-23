<?php
include 'db.php';


$unit = $_GET['unit'];
$valid = $_GET['valid'];
if($unit != null){
    $result = mysqli_query($conn, "INSERT INTO `unit`(`unitName`) VALUES ('$unit')");
}
if( $valid != null){
    $query = mysqli_query($conn, "SELECT * from `unit` where unitName='$valid'");

    if (mysqli_num_rows($query) > 0) {
        echo "error";
    }
}

$auth = $_GET['auth'];

if($auth != null){

    $query = mysqli_query($conn, "SELECT * from `unit`");

    while ($result = mysqli_fetch_array($query)) {
        $unitName = $result['unitName'];
        $id = $result['id'];


        echo strval($id);
        echo ',';
        echo $unitName;
        echo '|';
    }
}
$dropBox=$_GET['dropbox'];
if($dropBox != null){

    $query = mysqli_query($conn, "SELECT * from `unit`");

    while ($result = mysqli_fetch_array($query)) {
        $unitName = $result['unitName'];


        echo $unitName;
        echo '|';
    }
}