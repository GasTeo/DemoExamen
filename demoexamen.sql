-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Хост: localhost
-- Время создания: Фев 27 2025 г., 15:38
-- Версия сервера: 5.7.25
-- Версия PHP: 7.1.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `demoexamcher`
--

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

CREATE TABLE `clients` (
  `ClientID` int(11) NOT NULL,
  `CompanyName` text NOT NULL,
  `NameClient` text NOT NULL,
  `ClientType` text NOT NULL,
  `Phone` text NOT NULL,
  `Rating` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `clients`
--

INSERT INTO `clients` (`ClientID`, `CompanyName`, `NameClient`, `ClientType`, `Phone`, `Rating`) VALUES
(1, 'Стальной бастион', 'Романов Виктор Сергеевич', 'ООО', '+7 900 123-45-67', 3),
(2, 'Оружейник Сидоров', 'Сидоров Алексей Петрович', 'ИП', '+7 901 234-56-78', 7),
(3, 'Крепость Армз', 'Гаврилов Артём Викторович', 'АО', '+7 902 345-67-89', 8),
(4, 'Iron Fang Defense', 'Michael \"Mike\" Harrison', 'LLC', '+1 555-123-4567', 10),
(5, 'ТехноАрсенал', 'Лебедев Константин Олегович', 'ЗАО', '+7 903 456-78-90', 6),
(6, 'Восточный калибр', 'Кузнецов Дмитрий Александрович', 'ООО', '+7 904 567-89-01', 8),
(7, 'Titan Arms', 'Jonathan Reynolds', 'Inc.', '+1 555-234-5678', 9),
(8, 'Дубровский Армз', 'Дубровский Сергей Игоревич', 'ИП', '+7 905 678-90-12', 7),
(9, 'Schwarzstahl Waffen', 'Hans Müller', 'GmbH', '+49 170 1234567', 9),
(10, 'Буря Оружие', 'Васильев Николай Евгеньевич', 'АО', '+7 906 789-01-23', 8);

-- --------------------------------------------------------

--
-- Структура таблицы `ordern`
--

CREATE TABLE `ordern` (
  `ClientID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `ProductName` text NOT NULL,
  `ProductData` date NOT NULL,
  `Price` int(11) NOT NULL,
  `ammount` int(11) NOT NULL,
  `summ` int(11) NOT NULL,
  `FinalSum` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `ordern`
--

INSERT INTO `ordern` (`ClientID`, `ProductID`, `ProductName`, `ProductData`, `Price`, `ammount`, `summ`, `FinalSum`) VALUES
(1, 1, 'Ствол 16 дюймов хромированный', '2024-01-15', 45000, 5, 2250000, 2250000),
(2, 2, 'Охотничий приклад из ореха', '2024-02-10', 25000, 30, 750000, 750000),
(3, 3, 'Тактический затвор усиленный', '2024-01-25', 70000, 40, 2800000, 2800000),
(4, 4, 'Магазин для карабина 30 патронов', '2024-01-30', 15000, 100, 1500000, 1500000),
(5, 5, 'Лазерный целеуказатель', '2024-02-05', 12000, 60, 720000, 720000),
(6, 6, 'Снайперский оптический прицел 6-24x50', '2024-02-12', 95000, 15, 1425000, 1425000),
(7, 7, 'Тактическая рукоятка передняя', '2024-01-20', 18000, 25, 450000, 450000),
(8, 8, 'Кожаная кобура для револьвера', '2024-01-18', 20000, 10, 200000, 200000),
(9, 9, 'Комплект УСМ (ударно-спусковой механизм)', '2024-02-08', 35000, 35, 1225000, 1225000),
(10, 10, 'Дульный тормоз-компенсатор', '2024-02-15', 30000, 45, 1350000, 1350000);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`ClientID`);

--
-- Индексы таблицы `ordern`
--
ALTER TABLE `ordern`
  ADD PRIMARY KEY (`ClientID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `clients`
--
ALTER TABLE `clients`
  MODIFY `ClientID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT для таблицы `ordern`
--
ALTER TABLE `ordern`
  MODIFY `ClientID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
