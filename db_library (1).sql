-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 13, 2024 at 12:15 PM
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
-- Database: `db_library`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_buku`
--

CREATE TABLE `tbl_buku` (
  `id_buku` int(11) NOT NULL,
  `judul_buku` varchar(40) NOT NULL,
  `pengarang` varchar(40) NOT NULL,
  `tahun_terbit` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_buku`
--

INSERT INTO `tbl_buku` (`id_buku`, `judul_buku`, `pengarang`, `tahun_terbit`) VALUES
(1, 'Laut Bercerita', 'Leila Chudori', 2013),
(2, 'The Principles of Power', 'Dion Yulianto', 2024),
(3, 'Filosofi Teras', 'Henry Manampiring', 2018),
(4, 'Bumi', 'Tere Liye', 2021),
(5, 'Bulan', 'Tere Liye', 2015),
(6, 'Matahari', 'Tere Liye', 2016),
(7, 'Atomic Habits', 'James Clear', 2018),
(8, 'The Psychology of Money', 'Morgan Housel', 2020),
(9, 'Rich Dad Poor Dad', 'Robert Kiyosaki', 2016),
(10, 'Seni Berbicara', 'Larry King', 2007);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_loginadmin`
--

CREATE TABLE `tbl_loginadmin` (
  `id` int(11) NOT NULL,
  `username` varchar(40) NOT NULL,
  `password` varchar(35) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_loginuser`
--

CREATE TABLE `tbl_loginuser` (
  `id` int(11) NOT NULL,
  `username` varchar(40) NOT NULL,
  `password` varchar(35) NOT NULL,
  `foto` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_loginuser`
--

INSERT INTO `tbl_loginuser` (`id`, `username`, `password`, `foto`) VALUES
(2, 'admin', 'admin', 'ec48b4e1-858c-49f9-b7ef-92f686dbd66c.jpg'),
(3, 'Anjay', 'Rusia', ''),
(7, 'Gabriel', '12345', '4a6c56df-85ec-4eaf-97e4-fb88cc288f14.jpg'),
(8, 'Marbot', '22222', 'a3dc65a4-a2f1-4af8-b0c4-8581606edc92.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_peminjaman`
--

CREATE TABLE `tbl_peminjaman` (
  `id_peminjam` int(11) NOT NULL,
  `nama_peminjam` varchar(40) NOT NULL,
  `tanggal_pinjam` date NOT NULL,
  `tanggal_kembali` date NOT NULL,
  `judul_buku` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_peminjaman`
--

INSERT INTO `tbl_peminjaman` (`id_peminjam`, `nama_peminjam`, `tanggal_pinjam`, `tanggal_kembali`, `judul_buku`) VALUES
(1, 'Gabriel Kaunang', '2024-11-02', '2024-11-23', 'Seni Berbicara'),
(3, 'Kevin', '2024-11-01', '2024-11-21', 'Bulan'),
(4, 'Nicholas', '2024-11-03', '2024-11-03', 'Matahari'),
(5, 'Varel', '2024-11-08', '2024-11-30', 'Laut bercerita'),
(6, 'Marbot', '2024-11-04', '2024-11-20', 'Atomic Habits'),
(7, 'Albun', '2024-11-04', '2024-12-11', 'Filosofi Teras'),
(8, 'Abu', '2024-11-06', '2024-12-06', 'Bumi'),
(9, 'Gabriel Kaunang', '2024-11-08', '2024-11-30', 'The Psychology of Money');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_buku`
--
ALTER TABLE `tbl_buku`
  ADD PRIMARY KEY (`id_buku`);

--
-- Indexes for table `tbl_loginadmin`
--
ALTER TABLE `tbl_loginadmin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_loginuser`
--
ALTER TABLE `tbl_loginuser`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_peminjaman`
--
ALTER TABLE `tbl_peminjaman`
  ADD PRIMARY KEY (`id_peminjam`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_buku`
--
ALTER TABLE `tbl_buku`
  MODIFY `id_buku` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `tbl_loginadmin`
--
ALTER TABLE `tbl_loginadmin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_loginuser`
--
ALTER TABLE `tbl_loginuser`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `tbl_peminjaman`
--
ALTER TABLE `tbl_peminjaman`
  MODIFY `id_peminjam` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
