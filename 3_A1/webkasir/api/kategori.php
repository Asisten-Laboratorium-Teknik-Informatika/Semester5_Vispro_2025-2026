<?php
header('Content-Type: application/json');
header('Access-Control-Allow-Origin: *');

require_once '../config/database.php';

$conn = getConnection();

$sql = "SELECT * FROM kategori ORDER BY nama_kategori ASC";
$result = $conn->query($sql);
$kategori = [];

if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $kategori[] = $row;
    }
}

echo json_encode(['success' => true, 'data' => $kategori]);

$conn->close();
?>
