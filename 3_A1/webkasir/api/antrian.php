<?php
header('Content-Type: application/json');
header('Access-Control-Allow-Origin: *');
header('Access-Control-Allow-Methods: GET, POST, PUT, DELETE');
header('Access-Control-Allow-Headers: Content-Type');

require_once '../config/database.php';

$conn = getConnection();
$method = $_SERVER['REQUEST_METHOD'];

switch ($method) {
    case 'GET':
        // Get all pending orders or specific order
        if (isset($_GET['id'])) {
            $id = intval($_GET['id']);
            getOrderById($conn, $id);
        } else {
            $status = isset($_GET['status']) ? $_GET['status'] : 'pending';
            getOrders($conn, $status);
        }
        break;
        
    case 'POST':
        // Create new pending order
        createOrder($conn);
        break;
        
    case 'PUT':
        // Approve or reject order
        updateOrderStatus($conn);
        break;
        
    case 'DELETE':
        // Delete order
        if (isset($_GET['id'])) {
            deleteOrder($conn, intval($_GET['id']));
        }
        break;
        
    default:
        echo json_encode(['success' => false, 'message' => 'Method not allowed']);
}

$conn->close();

function getOrders($conn, $status) {
    $sql = "SELECT a.*, 
            (SELECT COUNT(*) FROM detail_antrian_pesanan WHERE id_antrian = a.id_antrian) as jumlah_item
            FROM antrian_pesanan a";
    
    if ($status !== 'all') {
        $sql .= " WHERE a.status = ?";
    }
    
    $sql .= " ORDER BY a.tanggal_pesan DESC";
    $stmt = $conn->prepare($sql);
    
    if ($status !== 'all') {
        $stmt->bind_param("s", $status);
    }
    
    $stmt->execute();
    $result = $stmt->get_result();
    
    $orders = [];
    while ($row = $result->fetch_assoc()) {
        $orders[] = $row;
    }
    
    echo json_encode(['success' => true, 'data' => $orders]);
}

function getOrderById($conn, $id) {
    // Get order header - nama_pembeli included automatically with SELECT *
    $sql = "SELECT * FROM antrian_pesanan WHERE id_antrian = ?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("i", $id);
    $stmt->execute();
    $order = $stmt->get_result()->fetch_assoc();
    
    if (!$order) {
        echo json_encode(['success' => false, 'message' => 'Order tidak ditemukan']);
        return;
    }
    
    // Get order details
    $sql = "SELECT * FROM detail_antrian_pesanan WHERE id_antrian = ?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("i", $id);
    $stmt->execute();
    $result = $stmt->get_result();
    
    $items = [];
    while ($row = $result->fetch_assoc()) {
        $items[] = $row;
    }
    
    $order['items'] = $items;
    
    echo json_encode(['success' => true, 'data' => $order]);
}

function createOrder($conn) {
    $data = json_decode(file_get_contents('php://input'), true);
    
    if (!$data || !isset($data['items']) || empty($data['items'])) {
        echo json_encode(['success' => false, 'message' => 'Data tidak valid']);
        return;
    }
    
    $conn->begin_transaction();
    
    try {
        $nama_pembeli = isset($data['nama_pembeli']) ? $data['nama_pembeli'] : null;
        
        $sql = "INSERT INTO antrian_pesanan (nama_pembeli, total, metode_pembayaran, jumlah_bayar, kembalian, status) 
                VALUES (?, ?, ?, ?, ?, 'pending')";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param("sdsdd", 
            $nama_pembeli,
            $data['total'], 
            $data['metode_pembayaran'], 
            $data['jumlah_bayar'], 
            $data['kembalian']
        );
        $stmt->execute();
        
        $id_antrian = $conn->insert_id;
        
        // Insert detail antrian
        foreach ($data['items'] as $item) {
            $sql = "INSERT INTO detail_antrian_pesanan (id_antrian, kode_barang, nama_barang, harga, jumlah, subtotal) 
                    VALUES (?, ?, ?, ?, ?, ?)";
            $stmt = $conn->prepare($sql);
            $stmt->bind_param("issdid", 
                $id_antrian, 
                $item['kode_barang'], 
                $item['nama_barang'],
                $item['harga'], 
                $item['jumlah'], 
                $item['subtotal']
            );
            $stmt->execute();
        }
        
        $conn->commit();
        
        echo json_encode([
            'success' => true, 
            'message' => 'Pesanan berhasil dibuat, menunggu persetujuan',
            'id_antrian' => $id_antrian
        ]);
        
    } catch (Exception $e) {
        $conn->rollback();
        echo json_encode(['success' => false, 'message' => 'Gagal membuat pesanan: ' . $e->getMessage()]);
    }
}

function updateOrderStatus($conn) {
    $data = json_decode(file_get_contents('php://input'), true);
    
    if (!isset($data['id_antrian']) || !isset($data['status'])) {
        echo json_encode(['success' => false, 'message' => 'Data tidak lengkap']);
        return;
    }
    
    $id_antrian = intval($data['id_antrian']);
    $status = $data['status'];
    
    // Validate status
    if (!in_array($status, ['approved', 'rejected'])) {
        echo json_encode(['success' => false, 'message' => 'Status tidak valid']);
        return;
    }
    
    $conn->begin_transaction();
    
    try {
        if ($status === 'approved') {
            // Get order data
            $sql = "SELECT * FROM antrian_pesanan WHERE id_antrian = ? AND status = 'pending'";
            $stmt = $conn->prepare($sql);
            $stmt->bind_param("i", $id_antrian);
            $stmt->execute();
            $order = $stmt->get_result()->fetch_assoc();
            
            if (!$order) {
                throw new Exception('Pesanan tidak ditemukan atau sudah diproses');
            }
            
            // Get order items
            $sql = "SELECT * FROM detail_antrian_pesanan WHERE id_antrian = ?";
            $stmt = $conn->prepare($sql);
            $stmt->bind_param("i", $id_antrian);
            $stmt->execute();
            $items = $stmt->get_result()->fetch_all(MYSQLI_ASSOC);
            
            // Check stock availability
            foreach ($items as $item) {
                $sql = "SELECT stok FROM barang WHERE kode_barang = ?";
                $stmt = $conn->prepare($sql);
                $stmt->bind_param("s", $item['kode_barang']);
                $stmt->execute();
                $barang = $stmt->get_result()->fetch_assoc();
                
                if ($barang['stok'] < $item['jumlah']) {
                    throw new Exception("Stok {$item['nama_barang']} tidak mencukupi (tersisa: {$barang['stok']})");
                }
            }
            
            $sql = "INSERT INTO transaksi (tanggal, total) VALUES (NOW(), ?)";
            $stmt = $conn->prepare($sql);
            $stmt->bind_param("d", $order['total']);
            $stmt->execute();
            
            $id_transaksi = $conn->insert_id;
            
            // Insert detail transaksi and update stock
            foreach ($items as $item) {
                // Insert detail
                $sql = "INSERT INTO detail_transaksi (id_transaksi, kode_barang, harga, jumlah, subtotal) 
                        VALUES (?, ?, ?, ?, ?)";
                $stmt = $conn->prepare($sql);
                $stmt->bind_param("isdid", 
                    $id_transaksi, 
                    $item['kode_barang'], 
                    $item['harga'], 
                    $item['jumlah'], 
                    $item['subtotal']
                );
                $stmt->execute();
                
                // Update stock
                $sql = "UPDATE barang SET stok = stok - ? WHERE kode_barang = ?";
                $stmt = $conn->prepare($sql);
                $stmt->bind_param("is", $item['jumlah'], $item['kode_barang']);
                $stmt->execute();
            }
            
            // Update antrian status
            $sql = "UPDATE antrian_pesanan SET status = 'approved', tanggal_update = NOW() WHERE id_antrian = ?";
            $stmt = $conn->prepare($sql);
            $stmt->bind_param("i", $id_antrian);
            $stmt->execute();
            
            $conn->commit();
            
            echo json_encode([
                'success' => true, 
                'message' => 'Pesanan disetujui dan transaksi berhasil dicatat',
                'id_transaksi' => $id_transaksi
            ]);
            
        } else {
            // Reject order
            $catatan = isset($data['catatan']) ? $data['catatan'] : null;
            
            $sql = "UPDATE antrian_pesanan SET status = 'rejected', catatan = ?, tanggal_update = NOW() WHERE id_antrian = ?";
            $stmt = $conn->prepare($sql);
            $stmt->bind_param("si", $catatan, $id_antrian);
            $stmt->execute();
            
            $conn->commit();
            
            echo json_encode([
                'success' => true, 
                'message' => 'Pesanan ditolak'
            ]);
        }
        
    } catch (Exception $e) {
        $conn->rollback();
        echo json_encode(['success' => false, 'message' => $e->getMessage()]);
    }
}

function deleteOrder($conn, $id) {
    $sql = "DELETE FROM antrian_pesanan WHERE id_antrian = ? AND status = 'pending'";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("i", $id);
    $stmt->execute();
    
    if ($stmt->affected_rows > 0) {
        echo json_encode(['success' => true, 'message' => 'Pesanan dihapus']);
    } else {
        echo json_encode(['success' => false, 'message' => 'Pesanan tidak ditemukan atau sudah diproses']);
    }
}
?>
