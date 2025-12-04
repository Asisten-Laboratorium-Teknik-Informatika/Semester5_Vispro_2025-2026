<?php
header('Access-Control-Allow-Origin: *');

$gambar = isset($_GET['path']) ? $_GET['path'] : '';

if (empty($gambar)) {
    header('Content-Type: image/svg+xml');
    echo '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="200" viewBox="0 0 200 200"><rect fill="#f5f5f5" width="200" height="200"/><text x="100" y="100" text-anchor="middle" fill="#999" font-size="40">📦</text></svg>';
    exit;
}

// Path gambar sudah full path dari database
$imagePath = $gambar;

if (file_exists($imagePath)) {
    $mimeType = mime_content_type($imagePath);
    header('Content-Type: ' . $mimeType);
    header('Cache-Control: max-age=86400');
    readfile($imagePath);
} else {
    header('Content-Type: image/svg+xml');
    echo '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="200" viewBox="0 0 200 200"><rect fill="#f5f5f5" width="200" height="200"/><text x="100" y="100" text-anchor="middle" fill="#999" font-size="40">📦</text></svg>';
}
?>
