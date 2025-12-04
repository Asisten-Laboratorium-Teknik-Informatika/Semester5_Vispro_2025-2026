<?php
header('Content-Type: application/json');
header('Access-Control-Allow-Origin: *');
header('Access-Control-Allow-Methods: GET');

require_once '../config/database.php';

$conn = getConnection();

$kategori = isset($_GET['kategori']) ? trim($_GET['kategori']) : '';
$search = isset($_GET['search']) ? trim($_GET['search']) : '';

$sql = "SELECT b.*, k.nama_kategori 
        FROM barang b 
        LEFT JOIN kategori k ON b.kategori = k.kode_kategori 
        WHERE b.stok > 0";

if (!empty($kategori)) {
    $sql .= " AND (b.kategori = '" . $conn->real_escape_string($kategori) . "' 
              OR k.kode_kategori = '" . $conn->real_escape_string($kategori) . "')";
}

if (!empty($search)) {
    $sql .= " AND b.nama_barang LIKE '%" . $conn->real_escape_string($search) . "%'";
}

$sql .= " ORDER BY b.nama_barang ASC";

$result = $conn->query($sql);
$barang = [];

if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $barang[] = $row;
    }
}

echo json_encode(['success' => true, 'data' => $barang]);

$conn->close();
?>
