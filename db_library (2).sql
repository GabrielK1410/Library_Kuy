-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 21, 2024 at 04:27 PM
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
  `tahun_terbit` int(11) NOT NULL,
  `stok_buku` int(11) NOT NULL,
  `batas_peminjaman` int(11) NOT NULL,
  `denda` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_buku`
--

INSERT INTO `tbl_buku` (`id_buku`, `judul_buku`, `pengarang`, `tahun_terbit`, `stok_buku`, `batas_peminjaman`, `denda`) VALUES
(1, 'Laut Bercerita', 'Leila Chudori', 2013, 2, 5, 5000),
(2, 'The Principles of Power', 'Dion Yulianto', 2024, 2, 3, 5000),
(3, 'Filosofi Teras', 'Henry Manampiring', 2018, 2, 5, 5000),
(4, 'Bumi', 'Tere Liye', 2021, 3, 3, 5000),
(5, 'Bulan', 'Tere Liye', 2015, 2, 4, 5000),
(6, 'Matahari', 'Tere Liye', 2016, 3, 5, 5000),
(7, 'Atomic Habits', 'James Clear', 2018, 3, 3, 5000),
(8, 'The Psychology of Money', 'Morgan Housel', 2020, 2, 4, 5000),
(9, 'Rich Dad Poor Dad', 'Robert Kiyosaki', 2016, 2, 5, 5000),
(10, 'Seni Berbicara', 'Larry King', 2007, 2, 3, 5000),
(14, 'Vispro', 'Rolly', 2025, 0, 3, 5000);

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
(2, 'admin', 'admin', 'd3c377e9-3b70-4b0e-be39-071f699b2d48.jpg'),
(3, 'Anjay', 'Rusia', ''),
(7, 'Gabriel', '12345', '4a6c56df-85ec-4eaf-97e4-fb88cc288f14.jpg'),
(8, 'Marbot', '22222', 'fdfc605c-ab8f-4941-9432-b3f0c757dd9f.jpg'),
(9, 'Kevin', '12345', '366ac536-400c-4dc2-b72f-cb46fdcf1f05.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_peminjaman`
--

CREATE TABLE `tbl_peminjaman` (
  `id_peminjam` int(11) NOT NULL,
  `nama_peminjam` varchar(40) NOT NULL,
  `tanggal_pinjam` date NOT NULL,
  `tanggal_kembali` date NOT NULL,
  `judul_buku` varchar(40) NOT NULL,
  `denda` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_peminjaman`
--

INSERT INTO `tbl_peminjaman` (`id_peminjam`, `nama_peminjam`, `tanggal_pinjam`, `tanggal_kembali`, `judul_buku`, `denda`) VALUES
(1, 'Gabriel Kaunang', '2024-11-02', '2024-11-23', 'Seni Berbicara', 5000),
(3, 'Kevin', '2024-11-01', '2024-11-21', 'Bulan', 5000),
(5, 'Varel', '2024-11-08', '2024-11-30', 'Laut bercerita', 5000),
(7, 'Albun', '2024-11-04', '2024-12-11', 'Filosofi Teras', 5000),
(9, 'Gabriel Kaunang', '2024-11-08', '2024-11-30', 'The Psychology of Money', 5000),
(18, 'astaga', '2024-11-19', '2024-11-22', 'Vispro', 5000),
(28, 'ahay', '2024-11-21', '2024-11-24', 'Vispro', 5000);

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
  MODIFY `id_buku` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `tbl_loginadmin`
--
ALTER TABLE `tbl_loginadmin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_loginuser`
--
ALTER TABLE `tbl_loginuser`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `tbl_peminjaman`
--
ALTER TABLE `tbl_peminjaman`
  MODIFY `id_peminjam` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
