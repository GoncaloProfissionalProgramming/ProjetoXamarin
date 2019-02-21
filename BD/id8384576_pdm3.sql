-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: 21-Fev-2019 às 17:06
-- Versão do servidor: 10.3.12-MariaDB
-- PHP Version: 7.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `id8384576_pdm3`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `aluno`
--

CREATE TABLE `aluno` (
  `id` int(11) NOT NULL,
  `nome` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `username` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `notasId` int(11) DEFAULT NULL,
  `turmaId` int(11) DEFAULT NULL,
  `curriculoId` int(11) DEFAULT NULL,
  `propinasId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `aluno`
--

INSERT INTO `aluno` (`id`, `nome`, `username`, `password`, `notasId`, `turmaId`, `curriculoId`, `propinasId`) VALUES
(39, 'a', 'a', 'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb', NULL, NULL, NULL, NULL),
(40, 'goncalo', 'goncalo', '73d0a219cada10f035a06dca225de294147e760b1d669744e6913e33f6a96fa8', NULL, NULL, NULL, NULL),
(41, 'aa', 'aa', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', NULL, NULL, NULL, NULL),
(42, 'testando', 'testando', '4b93ce345002ce3e6331dd4d4d0f3391c15c4e1afd91ad5e1da667cffd8eacaa', NULL, NULL, NULL, NULL),
(43, 'diogo', 'diogo', 'a0539f59d370f15ea8cc0f0062942888df62d28cb9ccc3975064a57cb87312e4', NULL, NULL, NULL, NULL),
(45, 'teste', 'teste', '46070d4bf934fb0d4b06d9e2c46e346944e322444900a435d7d9a95e6d7435f5', NULL, NULL, NULL, NULL),
(46, 'para', 'para', 'a1453f380fa9f1a08e84d4703e9c168fda1fb9a36976c41a03c8af842aa04ce5', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Estrutura da tabela `curriculo`
--

CREATE TABLE `curriculo` (
  `id` int(11) NOT NULL,
  `telemovel` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `morada` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `email` varchar(30) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `curriculo`
--

INSERT INTO `curriculo` (`id`, `telemovel`, `morada`, `email`) VALUES
(38, 'a', 'c', 'b'),
(39, 'teste', 'teste', 'teste'),
(41, '915882829', 'aaaaa', 'cruzgoncalo99@gmail.com'),
(42, '123', 'adf', 'asd'),
(43, '', '', ''),
(45, 'test', 'test', 'test'),
(46, '', '', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `exames`
--

CREATE TABLE `exames` (
  `id` int(11) NOT NULL,
  `turmaId` int(11) DEFAULT NULL,
  `profId` int(11) DEFAULT NULL,
  `dia` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `incio` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `fim` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `disciplina` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `exames`
--

INSERT INTO `exames` (`id`, `turmaId`, `profId`, `dia`, `incio`, `fim`, `disciplina`) VALUES
(1, 2, NULL, '13 Janeiro', '8:00 - 12:00', '12:00', 'PDM III'),
(2, 2, NULL, '18 Fevereiro', '13:00 - 18:00', '18:00', 'Projeto'),
(3, 1, NULL, '21 Janeiro', '8:00 - 10:00', '10:00', 'PDM III'),
(4, 1, NULL, '25 Fevereiro', '14:00 - 16:00', '16:00', 'Projeto');

-- --------------------------------------------------------

--
-- Estrutura da tabela `horario`
--

CREATE TABLE `horario` (
  `id` int(11) NOT NULL,
  `turmaId` int(11) DEFAULT NULL,
  `sala` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `disciplina` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `inicio` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `fim` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `diaDaSemana` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `horario`
--

INSERT INTO `horario` (`id`, `turmaId`, `sala`, `disciplina`, `inicio`, `fim`, `diaDaSemana`) VALUES
(1, 1, 'A4', 'PDM III', '8', '12', 'Sexta'),
(2, 2, 'A4', 'PDM III', '12', '16', 'Sexta'),
(3, 1, 'A7', 'Projeto', '14', '18', 'Quinta'),
(4, 2, 'A7', 'Projeto', '8', '12', 'Quinta');

-- --------------------------------------------------------

--
-- Estrutura da tabela `notas`
--

CREATE TABLE `notas` (
  `id` int(11) NOT NULL,
  `nota` int(11) DEFAULT NULL,
  `turmaId` int(11) DEFAULT NULL,
  `disciplina` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `nomeAluno` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `extenso` varchar(15) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `notas`
--

INSERT INTO `notas` (`id`, `nota`, `turmaId`, `disciplina`, `nomeAluno`, `extenso`) VALUES
(1, 12, 2, 'PDM III', 'AlunoA1', 'doze'),
(2, 15, 2, 'PDM III', 'AlunoA2', 'quinze'),
(3, 13, 1, 'PDM III', 'AlunoB1', 'treze'),
(4, 11, 1, 'PDM III', 'AlunoB2', 'onze'),
(5, 19, 2, 'Projeto', 'AlunoA1', 'dezanove'),
(6, 11, 2, 'Projeto', 'AlunoA2', 'onze'),
(7, 13, 1, 'Projeto', 'AlunoB2', 'treze'),
(8, 15, 1, 'Projeto', 'AlunoB1', 'quinze');

-- --------------------------------------------------------

--
-- Estrutura da tabela `professores`
--

CREATE TABLE `professores` (
  `id` int(11) NOT NULL,
  `nome` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `disciplina` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `propinas`
--

CREATE TABLE `propinas` (
  `id` int(11) NOT NULL,
  `alunoId` int(11) DEFAULT NULL,
  `mes` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `pagoN` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `propinas`
--

INSERT INTO `propinas` (`id`, `alunoId`, `mes`, `pagoN`) VALUES
(1, 39, 'Dezembro', 'Propina não paga'),
(2, 39, 'Janeiro', 'Propina Paga');

-- --------------------------------------------------------

--
-- Estrutura da tabela `turma`
--

CREATE TABLE `turma` (
  `id` int(11) NOT NULL,
  `nome` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `turma`
--

INSERT INTO `turma` (`id`, `nome`) VALUES
(2, 'ddmA'),
(1, 'ddmB');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aluno`
--
ALTER TABLE `aluno`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `username_2` (`username`),
  ADD KEY `notasId` (`notasId`),
  ADD KEY `turmaId` (`turmaId`),
  ADD KEY `curriculoId` (`curriculoId`),
  ADD KEY `propinasId` (`propinasId`);

--
-- Indexes for table `curriculo`
--
ALTER TABLE `curriculo`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `exames`
--
ALTER TABLE `exames`
  ADD PRIMARY KEY (`id`),
  ADD KEY `profId` (`profId`),
  ADD KEY `turmaId` (`turmaId`);

--
-- Indexes for table `horario`
--
ALTER TABLE `horario`
  ADD PRIMARY KEY (`id`),
  ADD KEY `turmaId` (`turmaId`);

--
-- Indexes for table `notas`
--
ALTER TABLE `notas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `turmaId` (`turmaId`) USING BTREE;

--
-- Indexes for table `professores`
--
ALTER TABLE `professores`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `propinas`
--
ALTER TABLE `propinas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `alunoId` (`alunoId`);

--
-- Indexes for table `turma`
--
ALTER TABLE `turma`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nome` (`nome`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aluno`
--
ALTER TABLE `aluno`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- AUTO_INCREMENT for table `exames`
--
ALTER TABLE `exames`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `professores`
--
ALTER TABLE `professores`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `propinas`
--
ALTER TABLE `propinas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `turma`
--
ALTER TABLE `turma`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `aluno`
--
ALTER TABLE `aluno`
  ADD CONSTRAINT `aluno_ibfk_1` FOREIGN KEY (`notasId`) REFERENCES `notas` (`id`),
  ADD CONSTRAINT `aluno_ibfk_2` FOREIGN KEY (`turmaId`) REFERENCES `turma` (`id`),
  ADD CONSTRAINT `aluno_ibfk_3` FOREIGN KEY (`curriculoId`) REFERENCES `curriculo` (`id`),
  ADD CONSTRAINT `aluno_ibfk_4` FOREIGN KEY (`propinasId`) REFERENCES `propinas` (`id`);

--
-- Limitadores para a tabela `exames`
--
ALTER TABLE `exames`
  ADD CONSTRAINT `exames_ibfk_1` FOREIGN KEY (`turmaId`) REFERENCES `turma` (`id`),
  ADD CONSTRAINT `exames_ibfk_2` FOREIGN KEY (`profId`) REFERENCES `professores` (`id`);

--
-- Limitadores para a tabela `horario`
--
ALTER TABLE `horario`
  ADD CONSTRAINT `horario_ibfk_1` FOREIGN KEY (`turmaId`) REFERENCES `turma` (`id`);

--
-- Limitadores para a tabela `notas`
--
ALTER TABLE `notas`
  ADD CONSTRAINT `notas_ibfk_1` FOREIGN KEY (`turmaId`) REFERENCES `turma` (`id`);

--
-- Limitadores para a tabela `propinas`
--
ALTER TABLE `propinas`
  ADD CONSTRAINT `propinas_ibfk_1` FOREIGN KEY (`alunoId`) REFERENCES `aluno` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
