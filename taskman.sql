-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 26, 2024 at 12:29 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `taskman`
--

-- --------------------------------------------------------

--
-- Table structure for table `hist_task`
--

CREATE TABLE `hist_task` (
  `id_task_history` int(11) NOT NULL,
  `id_task` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `subtitle` varchar(50) DEFAULT NULL,
  `description` varchar(750) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `hist_task`
--

INSERT INTO `hist_task` (`id_task_history`, `id_task`, `status`, `subtitle`, `description`, `created_at`, `created_by`) VALUES
(1, 4, 1, 'waiting list', 'antrian sedang banyak, harap bersabar', '2024-02-24 22:11:24', 3),
(2, 4, 3, 'On Order', 'Lebih maju karena ada permintaan ATK dalam jumlah besar dari all divisi', '2024-02-25 05:36:59', 3),
(3, 4, 3, 'Received', 'Diterima dari supplier', '2024-02-25 06:36:59', 3),
(4, 4, 4, 'Sent', 'Dikirim ke HRD', '2024-02-25 06:42:59', 3),
(5, 2, 1, 'Waiting List', 'Proses rekrutmen akan diadakan minggu depan', '2024-02-25 05:40:56', 2),
(6, 2, 3, 'Rekrutmen', 'Ada perubahan jadwal, rekrutmen akan diadakan pada hari senin 26 Februari 2024', '2024-02-25 05:42:19', 2),
(7, 4, 1, 'Received', 'Item diterima sesuai permintaan', '2024-02-25 05:42:45', 2);

-- --------------------------------------------------------

--
-- Table structure for table `m_divisi`
--

CREATE TABLE `m_divisi` (
  `id_divisi` int(11) NOT NULL,
  `name` varchar(250) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `m_divisi`
--

INSERT INTO `m_divisi` (`id_divisi`, `name`, `created_at`, `created_by`) VALUES
(1, 'Information Technology', '2024-02-24 17:50:05', 1),
(2, 'HRD', '2024-02-24 17:50:05', 1),
(3, 'General Affair', '2024-02-24 19:01:33', 1);

-- --------------------------------------------------------

--
-- Table structure for table `m_staff`
--

CREATE TABLE `m_staff` (
  `id_staff` int(11) NOT NULL,
  `id_divisi` int(11) DEFAULT NULL,
  `name` varchar(250) DEFAULT NULL,
  `username` varchar(250) DEFAULT NULL,
  `password` varchar(250) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `m_staff`
--

INSERT INTO `m_staff` (`id_staff`, `id_divisi`, `name`, `username`, `password`, `created_at`, `created_by`) VALUES
(1, 1, 'Mahardhika', 'itstaff', 'itstaff', '2024-02-24 17:50:36', 1),
(2, 2, 'Rania Mutiara', 'rania', 'rania', '2024-02-24 17:50:36', 1),
(3, 3, 'Andi', 'andi', 'andi', '2024-02-24 19:01:50', 1);

-- --------------------------------------------------------

--
-- Table structure for table `m_task`
--

CREATE TABLE `m_task` (
  `id_task` int(11) NOT NULL,
  `id_divisi` int(11) DEFAULT NULL,
  `id_staff` int(11) DEFAULT NULL,
  `title` varchar(250) DEFAULT NULL,
  `description` varchar(750) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `m_task`
--

INSERT INTO `m_task` (`id_task`, `id_divisi`, `id_staff`, `title`, `description`, `created_at`, `created_by`) VALUES
(1, 3, 2, 'Permintaan ATK', 'Request ATK untuk keperluan rapat besar bulan April 2024', '2024-02-24 19:02:10', 2),
(2, 2, 1, 'Permintaan Staff Tambahan', 'Berhubung cabang bertambah banyak, perlu dukungan 1 staff lagi untuk cover di bagian sidoarjo dan gresik', '2024-02-24 20:07:24', 1),
(3, 3, 2, 'Permintaan ATK', 'Request ATK untuk keperluan rapat besar bulan April 2024', '2024-02-24 20:11:06', 2),
(4, 3, 2, 'Permintaan ATK', 'Request ATK untuk keperluan rapat besar bulan April 2024', '2024-02-24 20:11:06', 2),
(5, 3, 2, 'Permintaan ATK', 'Request ATK untuk keperluan rapat besar bulan April 2024', '2024-02-24 20:11:06', 2),
(6, 3, 2, 'Permintaan ATK', 'Request ATK untuk keperluan rapat besar bulan April 2024', '2024-02-24 20:11:06', 2),
(7, 1, 2, 'Permintaan Pengadaan Finger', 'Perlu ada mesin finger baru untuk keperluan cabang baru', '2024-02-24 21:50:27', 2),
(8, 3, 2, 'Perbaikan Ruang Training', 'Jendelanya lepas tertiup angin', '2024-02-24 22:47:26', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `hist_task`
--
ALTER TABLE `hist_task`
  ADD PRIMARY KEY (`id_task_history`),
  ADD KEY `FK_FK_task_history` (`id_task`);

--
-- Indexes for table `m_divisi`
--
ALTER TABLE `m_divisi`
  ADD PRIMARY KEY (`id_divisi`);

--
-- Indexes for table `m_staff`
--
ALTER TABLE `m_staff`
  ADD PRIMARY KEY (`id_staff`),
  ADD KEY `FK_Relationship_1` (`id_divisi`);

--
-- Indexes for table `m_task`
--
ALTER TABLE `m_task`
  ADD PRIMARY KEY (`id_task`),
  ADD KEY `FK_FK_task_creator` (`id_staff`),
  ADD KEY `FK_FK_task_for` (`id_divisi`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `hist_task`
--
ALTER TABLE `hist_task`
  MODIFY `id_task_history` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `m_divisi`
--
ALTER TABLE `m_divisi`
  MODIFY `id_divisi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `m_staff`
--
ALTER TABLE `m_staff`
  MODIFY `id_staff` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `m_task`
--
ALTER TABLE `m_task`
  MODIFY `id_task` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `hist_task`
--
ALTER TABLE `hist_task`
  ADD CONSTRAINT `FK_FK_task_history` FOREIGN KEY (`id_task`) REFERENCES `m_task` (`id_task`) ON UPDATE CASCADE;

--
-- Constraints for table `m_staff`
--
ALTER TABLE `m_staff`
  ADD CONSTRAINT `FK_Relationship_1` FOREIGN KEY (`id_divisi`) REFERENCES `m_divisi` (`id_divisi`) ON UPDATE CASCADE;

--
-- Constraints for table `m_task`
--
ALTER TABLE `m_task`
  ADD CONSTRAINT `FK_FK_task_creator` FOREIGN KEY (`id_staff`) REFERENCES `m_staff` (`id_staff`) ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_FK_task_for` FOREIGN KEY (`id_divisi`) REFERENCES `m_divisi` (`id_divisi`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
