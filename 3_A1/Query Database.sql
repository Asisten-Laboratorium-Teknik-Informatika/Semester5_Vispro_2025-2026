create database inventaris_db;

use inventaris_db;

CREATE TABLE users (
    id_user INT(11) NOT NULL AUTO_INCREMENT,
    username VARCHAR(50) UNIQUE,
    password VARCHAR(255),
    role ENUM('admin','kasir') DEFAULT 'kasir',
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (id_user)
);

CREATE TABLE supplier (
    id_supplier INT(11) NOT NULL AUTO_INCREMENT,
    kode_supplier VARCHAR(10) NOT NULL UNIQUE,
    nama_supplier VARCHAR(100) NOT NULL,
    no_telp VARCHAR(20),
    alamat TEXT,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (id_supplier)
);

CREATE TABLE kategori (
    id_kategori INT(11) NOT NULL AUTO_INCREMENT,
    kode_kategori VARCHAR(20) UNIQUE,
    nama_kategori VARCHAR(100),
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (id_kategori)
);

CREATE TABLE barang (
    id INT(11) NOT NULL AUTO_INCREMENT,
    kode_barang VARCHAR(30) UNIQUE,
    nama_barang VARCHAR(100),
    kategori VARCHAR(50),
    supplier VARCHAR(50),
    harga_beli DECIMAL(10,2),
    harga_jual DECIMAL(10,2),
    stok INT(11),
    tanggal_masuk DATE,
    gambar VARCHAR(255),
    PRIMARY KEY (id)
);

CREATE TABLE transaksi (
    id INT(11) NOT NULL AUTO_INCREMENT,
    tanggal DATETIME,
    total DECIMAL(10,2),
    PRIMARY KEY (id)
);

CREATE TABLE detail_transaksi (
    id INT(11) NOT NULL AUTO_INCREMENT,
    id_transaksi INT(11),
    kode_barang VARCHAR(30),
    harga DECIMAL(10,2),
    jumlah INT(11),
    subtotal DECIMAL(10,2),
    PRIMARY KEY (id),
    KEY idx_transaksi (id_transaksi),
    CONSTRAINT fk_detail_transaksi_transaksi
        FOREIGN KEY (id_transaksi) REFERENCES transaksi(id)
        ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE antrian_pesanan (
    id_antrian INT(11) NOT NULL AUTO_INCREMENT,
    tanggal_pesan DATETIME DEFAULT CURRENT_TIMESTAMP,
    nama_pembeli VARCHAR(100),
    total DECIMAL(15,2) NOT NULL,
    metode_pembayaran ENUM('cash','qris') DEFAULT 'cash',
    jumlah_bayar DECIMAL(15,2) NOT NULL,
    kembalian DECIMAL(15,2) DEFAULT 0.00,
    status ENUM('pending','approved','rejected') DEFAULT 'pending',
    catatan TEXT,
    tanggal_update DATETIME ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY (id_antrian),
    KEY idx_status (status)
);

CREATE TABLE detail_antrian_pesanan (
    id_detail INT(11) NOT NULL AUTO_INCREMENT,
    id_antrian INT(11) NOT NULL,
    kode_barang VARCHAR(20) NOT NULL,
    nama_barang VARCHAR(100) NOT NULL,
    harga DECIMAL(15,2) NOT NULL,
    jumlah INT(11) NOT NULL,
    subtotal DECIMAL(15,2) NOT NULL,
    PRIMARY KEY (id_detail),
    KEY idx_antrian (id_antrian),
    KEY idx_kode_barang (kode_barang),
    CONSTRAINT fk_detail_antrian
        FOREIGN KEY (id_antrian) REFERENCES antrian_pesanan(id_antrian)
        ON DELETE CASCADE ON UPDATE CASCADE
);
