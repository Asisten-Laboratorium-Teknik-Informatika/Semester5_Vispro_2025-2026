-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 30, 2025 at 09:48 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_penjualan`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_barang`
--

CREATE TABLE `tbl_barang` (
  `id_barang` int(11) NOT NULL,
  `nama_barang` varchar(150) NOT NULL,
  `jenis_barang` varchar(100) NOT NULL,
  `satuan_barang` varchar(100) NOT NULL,
  `harga_beli` int(50) NOT NULL,
  `harga_jual` int(50) NOT NULL,
  `stok` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_barang`
--

INSERT INTO `tbl_barang` (`id_barang`, `nama_barang`, `jenis_barang`, `satuan_barang`, `harga_beli`, `harga_jual`, `stok`) VALUES
(1, 'Indomie Goreng', 'Makanan', 'Bungkus', 3000, 3500, 150),
(2, 'Chitato Sapi Panggang', 'Makanan', 'Bungkus', 7000, 8500, 50),
(3, 'SilverQueen Cokelat', 'Makanan', 'Batang', 10000, 12000, 40),
(4, 'Beng Beng', 'Makanan', 'Bungkus', 1500, 2000, 80),
(5, 'Oreo', 'Makanan', 'Bungkus', 3500, 4500, 60),
(6, 'Aqua 600ml', 'Minuman', 'Botol', 2500, 3000, 150),
(7, 'Teh Botol Sosro', 'Minuman', 'Botol', 4000, 5000, 100),
(8, 'Kopi Kapal Api Sachet', 'Minuman', 'Sachet', 1000, 1500, 200),
(9, 'Nutrisari Jeruk', 'Minuman', 'Sachet', 700, 1000, 200),
(10, 'Sprite Kaleng', 'Minuman', 'Kaleng', 5500, 7000, 80),
(11, 'Beras 5kg', 'Sembako', 'Karung', 55000, 65000, 20),
(12, 'Minyak Goreng 1L', 'Sembako', 'Liter', 15000, 18000, 30),
(13, 'Gula Pasir 1kg', 'Sembako', 'Plastik', 12000, 15000, 25),
(14, 'Garam Dapur 500g', 'Sembako', 'Bungkus', 3000, 4000, 50),
(15, 'Telur Ayam 1kg', 'Sembako', 'Kilogram', 25000, 28000, 10),
(16, 'Pensil 2B', 'Alat Tulis Kantor', 'Buah', 2000, 2500, 100),
(17, 'Pulpen Biru', 'Alat Tulis Kantor', 'Buah', 2500, 3000, 90),
(18, 'Penghapus', 'Alat Tulis Kantor', 'Buah', 1000, 1500, 70),
(19, 'Buku Tulis 38 Lembar', 'Alat Tulis Kantor', 'Buku', 3500, 4000, 60),
(20, 'Spidol Hitam', 'Alat Tulis Kantor', 'Buah', 4000, 5000, 30),
(21, 'Sabun Mandi Lifebuoy', 'Peralatan Kesehatan & Obat-Obatan', 'Batang', 2800, 3500, 100),
(22, 'Pasta Gigi Pepsodent', 'Peralatan Kesehatan & Obat-Obatan', 'Tube', 6000, 7000, 60),
(23, 'Sikat Gigi Formula', 'Peralatan Kesehatan & Obat-Obatan', 'Buah', 5000, 6000, 40),
(24, 'Shampoo Sunsilk 70ml', 'Peralatan Kesehatan & Obat-Obatan', 'Botol', 6500, 8000, 35),
(25, 'Detergen Rinso 800g', 'Peralatan Kesehatan & Obat-Obatan', 'Bungkus', 11000, 14000, 20),
(26, 'Sabun Cuci Piring Sunlight', 'Peralatan Kesehatan & Obat-Obatan', 'Botol', 4000, 5000, 50),
(27, 'Tissue Paseo', 'Peralatan Kesehatan & Obat-Obatan', 'Pack', 7000, 9000, 30),
(28, 'Minyak Kayu Putih 60ml', 'Peralatan Kesehatan & Obat-Obatan', 'Botol', 10000, 12000, 25),
(29, 'Obat Masuk Angin', 'Peralatan Kesehatan & Obat-Obatan', 'Sachet', 4500, 6000, 40),
(30, 'Lem Kertas', 'Alat Tulis Kantor', 'Buah', 2000, 2500, 70),
(31, 'Indomie Kuah Kardus', 'Makanan', 'Pack', 120000, 140000, 40),
(32, 'Indomie Kuah', 'Sembako', 'Bungkus', 2500, 3000, 120),
(33, 'Caffino', 'Minuman', 'PCS', 4000, 5000, 30),
(34, 'Pocari', 'Minuman', 'botol', 4500, 7000, 15);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_jual`
--

CREATE TABLE `tbl_jual` (
  `no_transaksi` int(20) NOT NULL,
  `id_entrypembelian` varchar(50) NOT NULL,
  `tanggal` date DEFAULT NULL,
  `grand_total` int(100) DEFAULT NULL,
  `dibayar` int(100) DEFAULT NULL,
  `kembalian` int(100) DEFAULT NULL,
  `kasir` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_jual`
--

INSERT INTO `tbl_jual` (`no_transaksi`, `id_entrypembelian`, `tanggal`, `grand_total`, `dibayar`, `kembalian`, `kasir`) VALUES
(0, 'TR20250610001', '2025-06-10', 41500, 50000, 8500, 'MSI'),
(0, 'TR20250610002', '2025-06-10', 19000, 20000, 1000, 'MSI'),
(0, 'TR20250610003', '2025-06-10', 99000, 100000, 1000, 'MSI'),
(0, 'TR20250610004', '2025-06-10', 38000, 40000, 2000, 'MSI'),
(0, 'TR20250610005', '2025-06-10', 24000, 30000, 6000, 'MSI'),
(0, 'TR20250610006', '2025-06-10', 35000, 35000, 0, 'MSI'),
(0, 'TR20250610007', '2025-06-10', 8000, 10000, 2000, 'MSI'),
(0, 'TR20250610008', '2025-06-10', 34000, 35000, 1000, 'MSI'),
(0, 'TR20250610009', '2025-06-10', 45000, 45000, 0, 'MSI'),
(0, 'TR20251114001', '2025-11-14', 52500, 60000, 7500, 'MSI'),
(0, 'TR20251116001', '2025-11-16', 49000, 50000, 1000, 'MSI');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_rinci_jual`
--

CREATE TABLE `tbl_rinci_jual` (
  `id_entrypembelian` varchar(50) NOT NULL,
  `id_barang` int(11) NOT NULL,
  `qty` int(11) DEFAULT NULL,
  `total_harga` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_rinci_jual`
--

INSERT INTO `tbl_rinci_jual` (`id_entrypembelian`, `id_barang`, `qty`, `total_harga`) VALUES
('TR20250610001', 5, 5, 22500),
('TR20250610001', 8, 10, 15000),
('TR20250610001', 9, 4, 4000),
('TR20250610002', 1, 3, 10500),
('TR20250610002', 2, 1, 8500),
('TR20250610003', 6, 3, 9000),
('TR20250610003', 12, 5, 90000),
('TR20250610005', 3, 2, 24000),
('TR20250610006', 1, 10, 35000),
('TR20250610007', 4, 4, 8000),
('TR20250610008', 2, 4, 34000),
('TR20250610009', 1, 3, 10500),
('TR20250610009', 3, 1, 12000),
('TR20250610009', 5, 5, 22500),
('TR20251111001', 1, 10, 35000),
('TR20251111001', 6, 5, 15000),
('TR20251114001', 1, 15, 52500),
('TR20251116001', 1, 14, 49000);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE `tbl_user` (
  `kode_user` varchar(15) NOT NULL,
  `nama_user` varchar(150) NOT NULL,
  `username` varchar(150) NOT NULL,
  `pwd` varchar(100) NOT NULL,
  `lvl` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`kode_user`, `nama_user`, `username`, `pwd`, `lvl`) VALUES
('KD001', 'Rio Fabreza', 'Rio', 'Rio123', 'Owner'),
('KD002', 'Fazila', 'Fazila', 'Fazila', 'Kasir');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_utang`
--

CREATE TABLE `tbl_utang` (
  `id_utang` varchar(15) NOT NULL,
  `nama_pelanggan` varchar(150) NOT NULL,
  `tgl_belanja` varchar(50) NOT NULL,
  `jmlh_utang` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_utang`
--

INSERT INTO `tbl_utang` (`id_utang`, `nama_pelanggan`, `tgl_belanja`, `jmlh_utang`) VALUES
('2', 'SupriantoS', '2025-10-12', 200000),
('3', 'Joko Anwar', '2025-08-09', 3500000),
('4', 'Rio S', '2025-11-09', 3000000),
('5', 'Joko Sumbing', '2025-09-16', 300000),
('6', 'Anri', '2025-06-10', 25000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_barang`
--
ALTER TABLE `tbl_barang`
  ADD PRIMARY KEY (`id_barang`),
  ADD UNIQUE KEY `id_barang` (`id_barang`);

--
-- Indexes for table `tbl_jual`
--
ALTER TABLE `tbl_jual`
  ADD PRIMARY KEY (`id_entrypembelian`,`no_transaksi`) USING BTREE;

--
-- Indexes for table `tbl_rinci_jual`
--
ALTER TABLE `tbl_rinci_jual`
  ADD PRIMARY KEY (`id_entrypembelian`,`id_barang`),
  ADD KEY `id_barang` (`id_barang`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbl_rinci_jual`
--
ALTER TABLE `tbl_rinci_jual`
  ADD CONSTRAINT `tbl_rinci_jual_ibfk_1` FOREIGN KEY (`id_barang`) REFERENCES `tbl_barang` (`id_barang`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
