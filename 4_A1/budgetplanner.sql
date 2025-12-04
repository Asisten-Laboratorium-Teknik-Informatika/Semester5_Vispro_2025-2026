-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 04 Des 2025 pada 16.04
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `budgetplanner`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi`
--

CREATE TABLE `transaksi` (
  `id` int(11) NOT NULL,
  `jenis` varchar(50) DEFAULT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `kategori` varchar(100) DEFAULT NULL,
  `deskripsi` text DEFAULT NULL,
  `tanggal` datetime DEFAULT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `transaksi`
--

INSERT INTO `transaksi` (`id`, `jenis`, `jumlah`, `kategori`, `deskripsi`, `tanggal`, `user_id`) VALUES
(1, 'Pengeluaran', 10000, 'Transportasi', 'angkot', '2025-11-19 12:31:04', 1),
(2, 'Pengeluaran', 20000, 'Makan dan Minum', 'Ayam Geprek', '2025-11-19 12:42:14', 1),
(3, 'Pemasukan', 100000, '', '', '2025-11-19 18:20:31', 2),
(4, 'Pengeluaran', 200000, 'Belanja', 'Jeans', '2025-11-19 18:20:47', 2),
(5, 'Pemasukan', 200000, '', '', '2025-11-19 18:21:06', 2),
(6, 'Pengeluaran', 100000, 'Belanja', 'Jeans', '2025-11-19 21:38:26', 2),
(7, 'Pemasukan', 100000, '', '', '2025-11-20 08:45:28', 2),
(8, 'Pengeluaran', 200000, 'Belanja', 'Hoodie', '2025-11-20 08:46:03', 2),
(9, 'Pemasukan', 10000, '', '', '2025-11-20 10:31:03', 4),
(10, 'Pengeluaran', 50000, 'Transportasi', 'grab', '2025-11-20 10:31:15', 4),
(11, 'Pemasukan', 100000, '', '', '2025-11-20 10:31:30', 4),
(12, 'Pemasukan', 10000, '', '', '2025-11-20 20:57:38', 5),
(13, 'Pengeluaran', 5000, 'Transportasi', 'Angkot', '2025-11-20 20:57:50', 5),
(14, 'Pengeluaran', 10000, 'Makan dan Minum', 'Geprek', '2025-11-20 20:58:07', 5),
(15, 'Pemasukan', 1000, '', '', '2025-12-03 20:55:58', 1),
(16, 'Pemasukan', 80000, '', '', '2025-12-03 20:57:40', 1),
(17, 'Pengeluaran', 100000, 'Lainnya', 'Healing', '2025-12-03 20:59:22', 1),
(18, 'Pengeluaran', 10000, 'Transportasi', 'Angkot', '2025-12-03 21:26:51', 6),
(19, 'Pemasukan', 50000, '', '', '2025-12-03 21:27:05', 6),
(20, 'Pengeluaran', 30000, 'Makan dan Minum', 'Makan Siang', '2025-12-03 21:37:03', 7),
(21, 'Pemasukan', 50000, '', '', '2025-12-03 21:38:02', 7),
(22, 'Pengeluaran', 20000, 'Transportasi', 'Grab', '2025-12-03 21:38:38', 7),
(23, 'Pengeluaran', 10000, 'Pilih Kategori', 'P', '2025-12-03 21:39:04', 7),
(24, 'Pengeluaran', 80000, 'Hiburan', 'a', '2025-12-03 21:39:37', 7),
(25, 'Pemasukan', 400000, '', '', '2025-12-03 21:40:33', 7),
(26, 'Pengeluaran', 400000, 'Pilih Kategori', 'p', '2025-12-03 21:40:42', 7),
(27, 'Pemasukan', 100000000, '', '', '2025-12-03 21:40:51', 7),
(28, 'Pengeluaran', 40000, 'Hiburan', 'Bioskop', '2025-12-04 11:36:40', 6),
(29, 'Pengeluaran', 20000, 'Belanja', 'Baju', '2025-12-04 11:57:35', 8),
(30, 'Pemasukan', 50000, '', '', '2025-12-04 11:57:46', 8),
(31, 'Pengeluaran', 10000, 'Transportasi', 'Angkot', '2025-12-04 12:00:51', 8),
(32, 'Pengeluaran', 5000, 'Transportasi', 'Angkot', '2025-12-04 12:13:19', 8),
(33, 'Pengeluaran', 20000, 'Makan dan Minum', 'makan ayam geprek', '2025-12-04 12:23:20', 9),
(34, 'Pemasukan', 50000, '', '', '2025-12-04 12:23:41', 9);

--
-- Trigger `transaksi`
--
DELIMITER $$
CREATE TRIGGER `after_transaction_insert` AFTER INSERT ON `transaksi` FOR EACH ROW INSERT INTO user_transaction_links (user_id, transaction_id, created_by)
VALUES (NEW.user_id, NEW.id, NEW.user_id)
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Struktur dari tabel `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `username` varchar(100) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `users`
--

INSERT INTO `users` (`id`, `name`, `username`, `email`, `password`, `created_at`) VALUES
(1, 'Yazid', 'LilFloppa', 'yazidnasution02@gmail.com', '$2a$11$lCaWGdNh/DHTE8we96tHpufK6vOQW..gZ0EtTppn954Msteq6dmWO', '2025-11-19 10:55:16'),
(2, 'Jef', 'Jep', 'Jep@example.com', '$2a$11$LEa1YHpc4HvxEtDlm7iamun6m/P3u/c1dmyWvKITHo7CwZemuxqJC', '2025-11-19 18:19:42'),
(3, 'nadira', 'noolep', 'nadiikuechler@gmail.com', '$2a$11$AnbHzKIisfNBH6dPgg60u.7rJX.QyR/e4Yk.f4uGu7oQnEPs1E7sm', '2025-11-20 08:54:47'),
(4, 'jid', 'jid', 'yyy@example.com', '$2a$11$JHAW7N5TgxDd9vYpPPa3Te6RZjQKImPUpKEaVwmqYfH3ZdRbn57Hu', '2025-11-20 10:30:22'),
(5, 'p', 'p', 'p@example.com', '$2a$11$rtFqkv3I.7a1qkLhWhL1hOu5ktu0pVWWVJJX.XlMMN3.ea37nLk2K', '2025-11-20 20:57:08'),
(6, 'P', 'PPP', 'ppp@example.com', '$2a$11$0i9K3MIU5D.zmaN/VONKRObH8LMw6JV/Ax9y9vVOME9j3BMpukd0O', '2025-12-03 21:26:15'),
(7, 'Yazid', 'Lek', 'aaa@example.com', '$2a$11$iZtV1TWUpjFuRTWKpIBb9OhSs4CPL68pQPLCsxclPG764863mRwLu', '2025-12-03 21:34:19'),
(8, 'Alberto', 'Carlos', 'carlos@example.com', '$2a$11$MttkB75sHTmvl45hOZF75eaBCr1sXpnFKDfaLN.sMbSUSYAFk9Yx6', '2025-12-04 11:57:16'),
(9, 'JIDDDD', 'andregosong', 'andrejelek@example.com', '$2a$11$.LD/YxckJHQonKVB4QybH.FwcJpmfDnA5NixavhGUvtXLtQPfKj4S', '2025-12-04 12:22:09');

-- --------------------------------------------------------

--
-- Struktur dari tabel `user_transaction_links`
--

CREATE TABLE `user_transaction_links` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `transaction_id` int(11) NOT NULL,
  `created_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `user_transaction_links`
--

INSERT INTO `user_transaction_links` (`id`, `user_id`, `transaction_id`, `created_by`) VALUES
(1, 8, 31, 8),
(2, 8, 32, 8),
(3, 9, 33, 9),
(4, 9, 34, 9);

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_transaksi_user` (`user_id`);

--
-- Indeks untuk tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indeks untuk tabel `user_transaction_links`
--
ALTER TABLE `user_transaction_links`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `transaction_id` (`transaction_id`),
  ADD KEY `created_by` (`created_by`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT untuk tabel `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT untuk tabel `user_transaction_links`
--
ALTER TABLE `user_transaction_links`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  ADD CONSTRAINT `fk_transaksi_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ketidakleluasaan untuk tabel `user_transaction_links`
--
ALTER TABLE `user_transaction_links`
  ADD CONSTRAINT `user_transaction_links_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `user_transaction_links_ibfk_2` FOREIGN KEY (`transaction_id`) REFERENCES `transaksi` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `user_transaction_links_ibfk_3` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
