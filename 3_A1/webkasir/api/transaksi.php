<?php
header('Content-Type: application/json');
header('Access-Control-Allow-Origin: *');
header('Access-Control-Allow-Methods: POST');
header('Access-Control-Allow-Headers: Content-Type');

require_once '../config/database.php';

if ($_SERVER['REQUEST_METHOD'] !== 'POST') {
    echo json_encode(['success' => false, 'message' => 'Method not allowed']);
    exit;
}

$data = json_decode(file_get_contents('php://input'), true);

if (!$data || !isset($data['items']) || empty($data['items'])) {
    echo json_encode(['success' => false, 'message' => 'Data tidak valid']);
    exit;
}

$conn = getConnection();
$conn->begin_transaction();

try {
    // Insert transaksi
    $total = $data['total'];
    $metode = $data['metode_pembayaran'];
    $bayar = $data['jumlah_bayar'];
    $kembalian = $data['kembalian'];
    
    $sql = "INSERT INTO transaksi (tanggal, total) VALUES (NOW(), ?)";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("d", $total);
    $stmt->execute();
    
    $id_transaksi = $conn->insert_id;
    
    // Insert detail transaksi dan update stok
    foreach ($data['items'] as $item) {
        $sql = "INSERT INTO detail_transaksi (id_transaksi, kode_barang, harga, jumlah, subtotal) 
                VALUES (?, ?, ?, ?, ?)";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param("isdid", $id_transaksi, $item['kode_barang'], $item['harga'], $item['jumlah'], $item['subtotal']);
        $stmt->execute();
        
        // Update stok barang
        $sql = "UPDATE barang SET stok = stok - ? WHERE kode_barang = ?";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param("is", $item['jumlah'], $item['kode_barang']);
        $stmt->execute();
    }
    
    $conn->commit();
    
    echo json_encode([
        'success' => true, 
        'message' => 'Transaksi berhasil',
        'id_transaksi' => $id_transaksi
    ]);
    
} catch (Exception $e) {
    $conn->rollback();
    echo json_encode(['success' => false, 'message' => 'Transaksi gagal: ' . $e->getMessage()]);
}

$conn->close();
?>
