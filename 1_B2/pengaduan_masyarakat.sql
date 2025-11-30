-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 30, 2025 at 12:29 PM
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
-- Database: `pengaduan_masyarakat`
--

-- --------------------------------------------------------

--
-- Table structure for table `pengaduan`
--

CREATE TABLE `pengaduan` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `nama_pelapor` varchar(100) NOT NULL,
  `nomor_telepon` varchar(20) NOT NULL,
  `lokasi_kejadian` text NOT NULL,
  `jenis_kejadian` enum('Kecelakaan','Perampokan','Penipuan','Kerusakan Fasilitas','Lainnya') NOT NULL,
  `deskripsi` text NOT NULL,
  `foto_path` varchar(255) DEFAULT NULL,
  `status` enum('pending','diproses','selesai') DEFAULT 'pending',
  `tanggal_laporan` timestamp NOT NULL DEFAULT current_timestamp(),
  `tanggal_update` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pengaduan`
--

INSERT INTO `pengaduan` (`id`, `user_id`, `nama_pelapor`, `nomor_telepon`, `lokasi_kejadian`, `jenis_kejadian`, `deskripsi`, `foto_path`, `status`, `tanggal_laporan`, `tanggal_update`) VALUES
(1, 2, 'IhsanNurAlam', '083833802258', 'Tembung city', 'Kecelakaan', 'Di simpang lampu merah terjadi kecelakaan beruntun ', 'C:\\Users\\ADVAN\\Music\\Lab\\PemroVis Nadira\\PengaduanMasyarakat\\PengaduanMasyarakat\\bin\\Debug\\net8.0-windows\\Images\\639001045881638864_download (1).jpg', 'selesai', '2025-11-30 06:03:08', '2025-11-30 06:04:59'),
(2, 2, 'IhsanNurAlam', '083833802258', 'Susuk Jaya', 'Perampokan', 'kontol', 'C:\\Users\\ADVAN\\Music\\Lab\\PemroVis Nadira\\PengaduanMasyarakat\\PengaduanMasyarakat\\bin\\Debug\\net8.0-windows\\Images\\639001108307514318_download (1).jpg', 'pending', '2025-11-30 07:47:10', '2025-11-30 07:47:10');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `nama_lengkap` varchar(100) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `role` enum('user','admin') DEFAULT 'user',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `nama_lengkap`, `email`, `role`, `created_at`) VALUES
(1, 'admin', 'admin123', 'Administrator', 'admin@pengaduan.com', 'admin', '2025-11-30 05:32:56'),
(2, 'Ihsan', '112112', 'IhsanNurAlam', 'ihsannuralam202@gmail.com', 'user', '2025-11-30 05:59:05');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pengaduan`
--
ALTER TABLE `pengaduan`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pengaduan`
--
ALTER TABLE `pengaduan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `pengaduan`
--
ALTER TABLE `pengaduan`
  ADD CONSTRAINT `pengaduan_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
