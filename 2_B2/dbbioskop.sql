-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 30, 2025 at 07:25 AM
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
-- Database: `dbbioskop`
--

-- --------------------------------------------------------

--
-- Table structure for table `detailpemesanan`
--

CREATE TABLE `detailpemesanan` (
  `DetailID` int(11) NOT NULL,
  `PemesananID` int(11) DEFAULT NULL,
  `KursiID` int(11) DEFAULT NULL,
  `JadwalID` int(11) NOT NULL,
  `UserID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `detailpemesanan`
--

INSERT INTO `detailpemesanan` (`DetailID`, `PemesananID`, `KursiID`, `JadwalID`, `UserID`) VALUES
(1, 1, 10, 1, NULL),
(2, 2, 9, 1, NULL),
(3, 3, 8, 1, NULL),
(4, 4, 46, 30, NULL),
(5, 4, 47, 30, NULL),
(6, 4, 48, 30, NULL),
(7, 4, 49, 30, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `films`
--

CREATE TABLE `films` (
  `FilmID` int(11) NOT NULL,
  `Judul` varchar(255) NOT NULL,
  `DurasiMenit` int(11) DEFAULT NULL,
  `Genre` varchar(100) DEFAULT NULL,
  `Sinopsis` text DEFAULT NULL,
  `PathPoster` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `films`
--

INSERT INTO `films` (`FilmID`, `Judul`, `DurasiMenit`, `Genre`, `Sinopsis`, `PathPoster`) VALUES
(1, 'Avangers:Infinity War', 181, 'Action/Sci-Fi', 'perjuangan Avengers dan sekutunya untuk menghentikan Thanos, seorang titan jahat, yang bertekad mengumpulkan keenam Infinity Stones untuk memusnahkan separuh kehidupan di alam semesta. ', '.\\Posters\\avengers.jpeg'),
(2, 'Bumi Tanpa Senja\r\n', 135, 'Sci-Fi, Thriller\r\n', 'Pada tahun 2077, Matahari tiba-tiba meredup dan mengancam kehidupan di Bumi. Seorang ilmuwan rekayasa iklim, Elara, menemukan bahwa satu-satunya cara untuk menghidupkan kembali bintang adalah dengan meluncurkan inti energi yang disimpan di stasiun ruang angkasa yang hilang. Ia harus berpacu dengan waktu, menghadapi bahaya antariksa dan pengkhianatan dari dalam timnya sendiri, sebelum Bumi membeku selamanya.\r\n', '.\\Posters\\bumi.jpg'),
(6, 'A Man Called Otto', 126, 'Drama/Komedi', 'Film A Man Called Otto bercerita tentang Otto Anderson, seorang pria paruh baya yang pemarah dan sinis setelah istrinya meninggal dunia. Merasa hidupnya tidak berarti, Otto berulang kali mencoba bunuh diri, namun usahanya selalu gagal karena kehadiran tetangga-tetangga barunya, terutama keluarga muda yang penuh keceriaan, yang perlahan-lahan mengubah pandangan dan kehidupannya.\r\n', '.\\Posters\\otto.jpg'),
(7, 'Gran Turismo', 134, 'Olahraga/Laga', 'Gran Turismo diangkat dari kisah nyata menggemparkan dari sebuah regu kuda hitamseorang pemain gim dari kelas pekerja, seorang mantan pebalap mobil yang redup, dan seorang eksekutif olahraga balap yang idealis. Bersama-sama mereka mengambil risiko besar dan berjuang masuk dalam olahraga paling elit di dunia.\r\n', '.\\Posters\\granturismo.jpg'),
(8, 'Paw Patrol The Movie\r\n', 86, 'Kartun/Animasi', 'Saat saingan terbesar mereka, Humdinger, menjadi Walikota Adventure City terdekat dan mulai membuat kekacauan, Ryder dan anak anjing heroik favorit semua orang berusaha keras untuk menghadapi tantangan secara langsung.\r\n', '.\\Posters\\paw.jpg'),
(9, 'John Wick\r\n', 110, 'Action and crime', ' Polisi ganas Ma Seok-do kembali Kali ini, ke Investigasi Metro! Tujuh tahun setelah penangkapan di Vietnam, Ma Seok-do bergabung dengan regu baru untuk menyelidiki kasus pembunuhan. Setelah ia mengetahui kasus ini melibatkan penghancuran obat sintetis, ia mulai menginvenstigasi lebih dalam...Sementara itu, pria di balik itu semuaJoo Sung-chultidak berhenti mencari masalah, dan distributor narkoba Jepang, Ricky dan gengnya datang ke Korea untuk bergabung dalam kekacauan ini. akan banyak hal gila yang diluar kendali...Sudah waktunya untuk memusnahkan para bajingan lagi Jika mereka ingin masalah, beri mereka masalah!\r\n', '.\\Posters\\john.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `jadwal`
--

CREATE TABLE `jadwal` (
  `JadwalID` int(11) NOT NULL,
  `FilmID` int(11) DEFAULT NULL,
  `StudioID` int(11) DEFAULT NULL,
  `TanggalTayang` date NOT NULL,
  `JamMulai` time NOT NULL,
  `Harga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `jadwal`
--

INSERT INTO `jadwal` (`JadwalID`, `FilmID`, `StudioID`, `TanggalTayang`, `JamMulai`, `Harga`) VALUES
(1, 1, 1, '2025-12-10', '14:00:00', 50000),
(2, 1, 2, '2025-12-10', '18:00:00', 75000),
(3, 1, 3, '2025-12-11', '14:00:00', 50000),
(4, 1, 4, '2025-12-12', '18:00:00', 75000),
(7, 2, 1, '2025-12-10', '17:30:00', 50000),
(8, 2, 2, '2025-12-10', '19:00:00', 75000),
(9, 2, 3, '2025-12-11', '13:30:00', 50000),
(10, 2, 4, '2025-12-11', '19:00:00', 75000),
(13, 6, 1, '2025-12-10', '20:00:00', 50000),
(14, 6, 2, '2025-12-10', '19:30:00', 75000),
(15, 6, 3, '2025-12-11', '13:30:00', 50000),
(16, 6, 4, '2025-12-12', '14:30:00', 75000),
(21, 7, 1, '2025-12-11', '13:00:00', 50000),
(22, 7, 2, '2025-12-11', '20:00:00', 75000),
(25, 7, 3, '2025-12-12', '15:30:00', 50000),
(26, 7, 4, '2025-12-12', '17:00:00', 75000),
(29, 8, 1, '2025-12-13', '13:00:00', 50000),
(30, 8, 2, '2025-12-13', '15:30:00', 75000),
(31, 8, 3, '2025-12-14', '16:00:00', 50000),
(32, 8, 4, '2025-12-07', '18:30:00', 75000),
(37, 9, 1, '2025-12-13', '16:00:00', 50000),
(38, 9, 2, '2025-12-13', '18:30:00', 75000),
(39, 9, 3, '2025-12-14', '13:30:00', 50000),
(40, 9, 4, '2025-12-14', '14:30:00', 75000);

-- --------------------------------------------------------

--
-- Table structure for table `kursi`
--

CREATE TABLE `kursi` (
  `KursiID` int(11) NOT NULL,
  `StudioID` int(11) DEFAULT NULL,
  `NomorKursi` varchar(5) NOT NULL,
  `Baris` varchar(10) NOT NULL,
  `Status` enum('Tersedia','Terisi') NOT NULL DEFAULT 'Terisi'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `kursi`
--

INSERT INTO `kursi` (`KursiID`, `StudioID`, `NomorKursi`, `Baris`, `Status`) VALUES
(4, 1, '1', 'A', 'Tersedia'),
(5, 1, '2', 'A', 'Tersedia'),
(6, 1, '3', 'A', 'Tersedia'),
(7, 1, '4', 'A', 'Tersedia'),
(8, 1, '5', 'A', 'Tersedia'),
(9, 1, '1', 'B', 'Tersedia'),
(10, 1, '2', 'B', 'Tersedia'),
(11, 1, '3', 'B', 'Tersedia'),
(12, 1, '4', 'B', 'Tersedia'),
(13, 1, '5', 'B', 'Tersedia'),
(14, 1, '1', 'C', 'Tersedia'),
(15, 1, '2', 'C', 'Tersedia'),
(16, 1, '3', 'C', 'Tersedia'),
(17, 1, '4', 'C', 'Tersedia'),
(18, 1, '5', 'C', 'Tersedia'),
(19, 1, '1', 'D', 'Tersedia'),
(20, 1, '2', 'D', 'Tersedia'),
(21, 1, '3', 'D', 'Tersedia'),
(22, 1, '4', 'D', 'Tersedia'),
(23, 1, '5', 'D', 'Tersedia'),
(24, 1, '1', 'E', 'Tersedia'),
(25, 1, '2', 'E', 'Tersedia'),
(26, 1, '3', 'E', 'Tersedia'),
(27, 1, '4', 'E', 'Tersedia'),
(28, 1, '5', 'E', 'Tersedia'),
(29, 1, '1', 'F', 'Tersedia'),
(30, 1, '2', 'F', 'Tersedia'),
(31, 1, '3', 'F', 'Tersedia'),
(32, 1, '4', 'F', 'Tersedia'),
(33, 1, '5', 'F', 'Tersedia'),
(34, 1, '1', 'G', 'Tersedia'),
(35, 1, '2', 'G', 'Tersedia'),
(36, 1, '3', 'G', 'Tersedia'),
(37, 1, '4', 'G', 'Tersedia'),
(38, 1, '5', 'G', 'Tersedia'),
(39, 1, '1', 'F', 'Tersedia'),
(40, 1, '2', 'F', 'Tersedia'),
(41, 1, '3', 'F', 'Tersedia'),
(42, 1, '4', 'F', 'Tersedia'),
(43, 1, '5', 'F', 'Tersedia'),
(44, 2, '1', 'A', 'Tersedia'),
(45, 2, '2', 'A', 'Tersedia'),
(46, 2, '3', 'A', 'Tersedia'),
(47, 2, '4', 'A', 'Tersedia'),
(48, 2, '5', 'A', 'Tersedia'),
(49, 2, '1', 'B', 'Tersedia'),
(50, 2, '2', 'B', 'Tersedia'),
(51, 2, '3', 'B', 'Tersedia'),
(52, 2, '4', 'B', 'Tersedia'),
(53, 2, '5', 'B', 'Tersedia'),
(54, 2, '1', 'C', 'Tersedia'),
(55, 2, '2', 'C', 'Tersedia'),
(56, 2, '3', 'C', 'Tersedia'),
(57, 2, '4', 'C', 'Tersedia'),
(58, 2, '5', 'C', 'Tersedia'),
(59, 2, '1', 'D', 'Tersedia'),
(60, 2, '2', 'D', 'Tersedia'),
(61, 2, '3', 'D', 'Tersedia'),
(62, 2, '4', 'D', 'Tersedia'),
(63, 2, '5', 'D', 'Tersedia'),
(64, 2, '1', 'E', 'Tersedia'),
(65, 2, '2', 'E', 'Tersedia'),
(66, 2, '3', 'E', 'Tersedia'),
(67, 2, '4', 'E', 'Tersedia'),
(68, 2, '5', 'E', 'Tersedia'),
(69, 2, '1', 'F', 'Tersedia'),
(70, 2, '2', 'F', 'Tersedia'),
(71, 2, '3', 'F', 'Tersedia'),
(72, 2, '4', 'F', 'Tersedia'),
(73, 2, '5', 'F', 'Tersedia'),
(74, 3, '1', 'A', 'Tersedia'),
(75, 3, '2', 'A', 'Tersedia'),
(76, 3, '3', 'A', 'Tersedia'),
(77, 3, '4', 'A', 'Tersedia'),
(78, 3, '5', 'A', 'Tersedia'),
(79, 3, '1', 'B', 'Tersedia'),
(80, 3, '2', 'B', 'Tersedia'),
(81, 3, '3', 'B', 'Tersedia'),
(82, 3, '4', 'B', 'Tersedia'),
(83, 3, '5', 'B', 'Tersedia'),
(84, 3, '1', 'C', 'Tersedia'),
(85, 3, '2', 'C', 'Tersedia'),
(86, 3, '3', 'C', 'Tersedia'),
(87, 3, '4', 'C', 'Tersedia'),
(88, 3, '5', 'C', 'Tersedia'),
(89, 3, '1', 'D', 'Tersedia'),
(90, 3, '2', 'D', 'Tersedia'),
(91, 3, '3', 'D', 'Tersedia'),
(92, 3, '4', 'D', 'Tersedia'),
(93, 3, '5', 'D', 'Tersedia'),
(94, 3, '1', 'E', 'Tersedia'),
(95, 3, '2', 'E', 'Tersedia'),
(96, 3, '3', 'E', 'Tersedia'),
(97, 3, '4', 'E', 'Tersedia'),
(98, 3, '5', 'E', 'Tersedia'),
(99, 3, '1', 'F', 'Tersedia'),
(100, 3, '2', 'F', 'Tersedia'),
(101, 3, '3', 'F', 'Tersedia'),
(102, 3, '4', 'F', 'Tersedia'),
(103, 3, '5', 'F', 'Tersedia'),
(104, 3, '1', 'G', 'Tersedia'),
(105, 3, '2', 'G', 'Tersedia'),
(106, 3, '3', 'G', 'Tersedia'),
(107, 3, '4', 'G', 'Tersedia'),
(108, 3, '5', 'G', 'Tersedia'),
(109, 3, '1', 'H', 'Tersedia'),
(110, 3, '2', 'H', 'Tersedia'),
(111, 3, '3', 'H', 'Tersedia'),
(112, 3, '4', 'H', 'Tersedia'),
(113, 3, '5', 'H', 'Tersedia'),
(114, 4, '1', 'A', 'Tersedia'),
(115, 4, '2', 'A', 'Tersedia'),
(116, 4, '3', 'A', 'Tersedia'),
(117, 4, '4', 'A', 'Tersedia'),
(118, 4, '5', 'A', 'Tersedia'),
(119, 4, '1', 'B', 'Tersedia'),
(120, 4, '2', 'B', 'Tersedia'),
(121, 4, '3', 'B', 'Tersedia'),
(122, 4, '4', 'B', 'Tersedia'),
(123, 4, '5', 'B', 'Tersedia'),
(124, 4, '1', 'C', 'Tersedia'),
(125, 4, '2', 'C', 'Tersedia'),
(126, 4, '3', 'C', 'Tersedia'),
(127, 4, '4', 'C', 'Tersedia'),
(128, 4, '5', 'C', 'Tersedia'),
(129, 4, '1', 'D', 'Tersedia'),
(130, 4, '2', 'D', 'Tersedia'),
(131, 4, '3', 'D', 'Tersedia'),
(132, 4, '4', 'D', 'Tersedia'),
(133, 4, '5', 'D', 'Tersedia'),
(134, 4, '1', 'E', 'Tersedia'),
(135, 4, '2', 'E', 'Tersedia'),
(136, 4, '3', 'E', 'Tersedia'),
(137, 4, '4', 'E', 'Tersedia'),
(138, 4, '5', 'E', 'Tersedia'),
(139, 4, '1', 'F', 'Tersedia'),
(140, 4, '2', 'F', 'Tersedia'),
(141, 4, '3', 'F', 'Tersedia'),
(142, 4, '4', 'F', 'Tersedia'),
(143, 4, '5', 'F', 'Tersedia');

-- --------------------------------------------------------

--
-- Table structure for table `pemesanan`
--

CREATE TABLE `pemesanan` (
  `PemesananID` int(11) NOT NULL,
  `JadwalID` int(11) DEFAULT NULL,
  `NamaPemesan` varchar(100) DEFAULT NULL,
  `TanggalPesan` datetime DEFAULT current_timestamp(),
  `TotalHarga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pemesanan`
--

INSERT INTO `pemesanan` (`PemesananID`, `JadwalID`, `NamaPemesan`, `TanggalPesan`, `TotalHarga`) VALUES
(1, 1, 'budi', '2025-11-28 23:26:59', 50000),
(2, 1, 'budi', '2025-11-28 23:30:03', 50000),
(3, 1, 'budi', '2025-11-29 00:23:55', 50000),
(4, 30, 'budi', '2025-11-29 17:30:02', 300000);

-- --------------------------------------------------------

--
-- Table structure for table `studio`
--

CREATE TABLE `studio` (
  `StudioID` int(11) NOT NULL,
  `NamaStudio` varchar(50) NOT NULL,
  `Kapasitas` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `studio`
--

INSERT INTO `studio` (`StudioID`, `NamaStudio`, `Kapasitas`) VALUES
(1, 'Epic', 40),
(2, 'Legend', 30),
(3, 'Epic', 40),
(4, 'Legend', 30);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `PASSWORD` varchar(255) NOT NULL,
  `Role` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `Username`, `PASSWORD`, `Role`) VALUES
(1, 'Admin', '12345678', 'Admin'),
(2, 'budi', '123', 'Customer'),
(6, 'Eazy-G', '1234', 'Customer');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `detailpemesanan`
--
ALTER TABLE `detailpemesanan`
  ADD PRIMARY KEY (`DetailID`),
  ADD KEY `PemesananID` (`PemesananID`),
  ADD KEY `KursiID` (`KursiID`),
  ADD KEY `JadwalID` (`JadwalID`),
  ADD KEY `UserID` (`UserID`);

--
-- Indexes for table `films`
--
ALTER TABLE `films`
  ADD PRIMARY KEY (`FilmID`);

--
-- Indexes for table `jadwal`
--
ALTER TABLE `jadwal`
  ADD PRIMARY KEY (`JadwalID`),
  ADD KEY `FilmID` (`FilmID`),
  ADD KEY `StudioID` (`StudioID`);

--
-- Indexes for table `kursi`
--
ALTER TABLE `kursi`
  ADD PRIMARY KEY (`KursiID`),
  ADD KEY `StudioID` (`StudioID`);

--
-- Indexes for table `pemesanan`
--
ALTER TABLE `pemesanan`
  ADD PRIMARY KEY (`PemesananID`),
  ADD KEY `JadwalID` (`JadwalID`);

--
-- Indexes for table `studio`
--
ALTER TABLE `studio`
  ADD PRIMARY KEY (`StudioID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `detailpemesanan`
--
ALTER TABLE `detailpemesanan`
  MODIFY `DetailID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `films`
--
ALTER TABLE `films`
  MODIFY `FilmID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `jadwal`
--
ALTER TABLE `jadwal`
  MODIFY `JadwalID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT for table `kursi`
--
ALTER TABLE `kursi`
  MODIFY `KursiID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=144;

--
-- AUTO_INCREMENT for table `pemesanan`
--
ALTER TABLE `pemesanan`
  MODIFY `PemesananID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `studio`
--
ALTER TABLE `studio`
  MODIFY `StudioID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `detailpemesanan`
--
ALTER TABLE `detailpemesanan`
  ADD CONSTRAINT `detailpemesanan_ibfk_1` FOREIGN KEY (`PemesananID`) REFERENCES `pemesanan` (`PemesananID`),
  ADD CONSTRAINT `detailpemesanan_ibfk_2` FOREIGN KEY (`KursiID`) REFERENCES `kursi` (`KursiID`),
  ADD CONSTRAINT `detailpemesanan_ibfk_3` FOREIGN KEY (`JadwalID`) REFERENCES `jadwal` (`JadwalID`),
  ADD CONSTRAINT `detailpemesanan_ibfk_4` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `jadwal`
--
ALTER TABLE `jadwal`
  ADD CONSTRAINT `jadwal_ibfk_1` FOREIGN KEY (`FilmID`) REFERENCES `films` (`FilmID`),
  ADD CONSTRAINT `jadwal_ibfk_2` FOREIGN KEY (`StudioID`) REFERENCES `studio` (`StudioID`);

--
-- Constraints for table `kursi`
--
ALTER TABLE `kursi`
  ADD CONSTRAINT `kursi_ibfk_1` FOREIGN KEY (`StudioID`) REFERENCES `studio` (`StudioID`);

--
-- Constraints for table `pemesanan`
--
ALTER TABLE `pemesanan`
  ADD CONSTRAINT `pemesanan_ibfk_1` FOREIGN KEY (`JadwalID`) REFERENCES `jadwal` (`JadwalID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
