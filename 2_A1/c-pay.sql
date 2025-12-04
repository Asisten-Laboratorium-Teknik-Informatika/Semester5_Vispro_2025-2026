-- phpMyAdmin SQL Dump
-- version 3.2.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Nov 24, 2025 at 09:35 PM
-- Server version: 5.1.41
-- PHP Version: 5.3.1

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `c-pay`
--

-- --------------------------------------------------------

--
-- Table structure for table `meja`
--

CREATE TABLE IF NOT EXISTS `meja` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama_meja` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `meja`
--

INSERT INTO `meja` (`id`, `nama_meja`) VALUES
(1, 'Meja 1'),
(2, 'Meja 2'),
(3, 'Meja 3'),
(4, 'Meja 4'),
(5, 'Meja 5');

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE IF NOT EXISTS `orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `meja` varchar(50) DEFAULT NULL,
  `username` varchar(100) DEFAULT NULL,
  `total_harga` int(11) DEFAULT NULL,
  `tanggal` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(20) DEFAULT 'Belum Dibayar',
  `bayar` int(11) DEFAULT '0',
  `kembalian` int(11) DEFAULT '0',
  `created_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=17 ;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`id`, `meja`, `username`, `total_harga`, `tanggal`, `status`, `bayar`, `kembalian`, `created_at`) VALUES
(16, 'Meja 1', 'andre', 30000, '2025-11-24 21:31:02', 'Sudah Dibayar', 0, 0, '2025-11-24 21:31:02'),
(15, 'Meja 1', 'andre', 36000, '2025-11-24 21:24:45', 'Sudah Dibayar', 40000, 40, '2025-11-24 21:24:45'),
(14, 'Meja 5', 'andre', 75000, '2025-11-24 21:22:54', 'Sudah Dibayar', 90000, 6750, '2025-11-24 21:22:54'),
(13, 'Meja 1', 'andre', 5000, '2025-11-24 21:14:51', 'Sudah Dibayar', 10000, 4450, '2025-11-24 21:14:51'),
(12, 'Meja 1', 'andre', 30000, '2025-11-24 21:05:09', 'Sudah Dibayar', 40000, 6700, '2025-11-24 21:05:09');

-- --------------------------------------------------------

--
-- Table structure for table `order_items`
--

CREATE TABLE IF NOT EXISTS `order_items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) DEFAULT NULL,
  `produk` varchar(100) DEFAULT NULL,
  `harga` int(11) DEFAULT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `subtotal` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `order_id` (`order_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=23 ;

--
-- Dumping data for table `order_items`
--

INSERT INTO `order_items` (`id`, `order_id`, `produk`, `harga`, `jumlah`, `subtotal`) VALUES
(22, 16, 'Nasi Goreng', 15000, 2, 30000),
(21, 15, 'Ayam Geprek', 18000, 2, 36000),
(20, 14, 'Nasi Goreng', 15000, 5, 75000),
(19, 13, 'Es Teh', 5000, 1, 5000),
(18, 12, 'Nasi Goreng', 15000, 2, 30000);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE IF NOT EXISTS `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(100) NOT NULL,
  `tipe` enum('Makanan','Minuman') NOT NULL,
  `harga` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `nama`, `tipe`, `harga`) VALUES
(1, 'Nasi Goreng', 'Makanan', 15000),
(2, 'Mie Goreng', 'Makanan', 12000),
(3, 'Ayam Bakar', 'Makanan', 20000),
(4, 'Ayam Geprek', 'Makanan', 18000),
(5, 'Es Teh', 'Minuman', 5000),
(6, 'Es Jeruk', 'Minuman', 7000),
(7, 'Kopi Hitam', 'Minuman', 8000),
(8, 'Cappuccino', 'Minuman', 15000);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `username`, `password`) VALUES
(1, 'Andre Tri Ramadana', 'andre', 'andre'),
(2, 'Ramadana', 'ramadana', 'andre');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
