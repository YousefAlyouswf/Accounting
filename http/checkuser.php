<?php
include 'db.php';


$userNumber = $_GET['userNumber'];
$password = $_GET['password'];

$query = mysqli_query($conn, "SELECT * from `users` where number='$userNumber' and password = '$password'");


if (mysqli_num_rows($query) > 0) {

    while ($result = mysqli_fetch_array($query)) {
        $position = $result['position'];
        $name = $result['name'];
        echo $position;
        echo ',';
        echo $name;
    }

}else{
    echo "البيانات غير صحيحة";
}
