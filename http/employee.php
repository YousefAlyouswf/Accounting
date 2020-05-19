<?php
include 'db.php';

$query = mysqli_query($conn, "SELECT * from `users`");

while ($result = mysqli_fetch_array($query)) {
    $position = $result['position'];
    $name = $result['name'];
    $number = $result['number'];

    echo $name;
    echo ',';
    echo $number;

    echo ',';
    echo $position;
    echo '|';
}