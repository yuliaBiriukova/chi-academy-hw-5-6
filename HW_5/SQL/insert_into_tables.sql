USE Laboratory;

-- fill table Groups 

INSERT INTO Groups (gr_name, gr_temp) 
VALUES ('Общеклинический', 20),
('Биохимический', 18),
('Бактериологический', 5),
('Инфекционный', 18),
('Иммунологический', 18),
('Гормональный', 15);


-- fill table Analysis 

INSERT INTO Analysis (an_name, an_cost, an_price, an_group) 
VALUES ('Клинический анализ крови развернутый', 90, 185, 1),
('СОЭ (скорость оседания эритроцитов)', 35, 70, 1),
('Ретикулоциты (подсчет ретикулоцитарного индекса)', 40, 95, 1),
('Белок общий', 35, 75, 2),
('Глюкозотолерантный тест', 70, 140, 2),
('Витамин B12 (цианокобаламин)', 95, 190, 2),
('Бакпосев из носа + антибиотикограмма', 110, 230, 3),
('Коронавирус Covid-19 ', 100, 200, 4),
('Определение группы крови и резус-фактора', 60, 120, 5),
('Иммуноглобулин E общий (IgE)', 80, 170, 5),
('Кальцитонин', 150, 310, 6),
('Тиреоглобулин', 90, 190, 6),
('Инсулин', 70, 180, 6);

-- create temporary table #TempOrders 

SELECT ord_datetime, ord_an
INTO #TempOrders
FROM Orders;


-- fill temporary table #TempOrders with unsorted dates

INSERT INTO #TempOrders (ord_datetime, ord_an) 
VALUES 
('2020-02-01 10:45', 1),
('2020-02-01 17:54', 12),
('2020-02-02 14:15', 10),
('2020-02-02 18:50', 7),
('2020-02-03 07:19', 2),
('2020-02-04 12:26', 1),
('2020-02-05 08:11', 6),
('2020-02-05 13:45', 10),
('2020-02-05 18:11', 12),
('2020-02-06 13:14', 12),
('2020-02-07 21:43', 9),
('2020-02-07 13:34', 5),
('2020-02-07 14:43', 5),
('2020-02-07 19:00', 1),
('2020-02-08 09:18', 2),
('2020-02-08 19:45', 2),
('2020-02-09 07:19', 8),
('2020-02-09 15:34', 9),
('2020-02-10 11:20', 7),
('2020-02-10 12:39', 7),
('2020-02-10 14:39', 3),
('2020-02-11 08:06', 3),
('2020-02-11 12:06', 1),
('2020-02-11 14:35', 3),
('2020-02-11 17:56', 6),
('2020-02-12 13:18', 13),
('2020-02-13 11:23', 5),
('2020-02-14 11:31', 4),
('2020-02-15 12:32', 1),
('2020-02-15 18:37', 4),
('2020-02-16 15:34', 12),
('2020-02-17 12:49', 10),
('2020-02-17 16:48', 7),
('2020-02-17 18:50', 11),
('2020-02-18 09:56', 1),
('2020-02-18 15:44', 2),
('2020-12-10 07:10', 1),
('2020-05-14 23:43', 12),
('2020-04-06 02:03', 6),
('2020-04-06 02:03', 10),
('2020-12-07 18:30', 2),
('2020-06-06 23:40', 4),
('2020-07-06 23:29', 12),
('2020-09-26 22:10', 9),
('2020-08-17 04:41', 1),
('2021-01-12 22:43', 12),
('2020-04-14 08:54', 13),
('2020-09-06 13:29', 2),
('2020-06-03 08:08', 5),
('2020-05-27 00:21', 6),
('2020-10-19 16:33', 6),
('2021-01-20 00:09', 7),
('2020-06-11 13:32', 13),
('2020-06-02 19:11', 8),
('2020-04-05 20:56', 10),
('2020-07-10 11:02', 11),
('2020-10-31 04:05', 5),
('2020-09-17 02:07', 3),
('2020-10-13 01:29', 2),
('2020-12-19 15:18', 5),
('2020-03-24 12:00', 7),
('2020-08-21 04:46', 10),
('2020-10-31 20:55', 12),
('2020-09-20 23:50', 9),
('2020-04-24 08:04', 12),
('2020-08-06 15:12', 7),
('2020-09-20 13:02', 3),
('2020-05-25 03:51', 4),
('2020-08-20 20:47', 10),
('2020-04-13 16:20', 12),
('2020-10-31 12:55', 11),
('2020-06-16 23:29', 9),
('2020-04-25 10:50', 10),
('2020-12-06 17:48', 8),
('2020-03-09 17:14', 7),
('2020-10-10 00:14', 7),
('2020-02-28 22:46', 6),
('2020-07-15 02:49', 1),
('2020-06-05 07:02', 2),
('2020-06-05 11:40', 2),
('2020-02-19 07:00', 4),
('2020-05-22 13:16', 5),
('2020-05-08 08:41', 6),
('2020-10-03 16:50', 11),
('2020-07-06 00:01', 9),
('2020-06-04 00:16', 8),
('2020-07-02 09:39', 8),
('2020-11-11 22:48', 10),
('2020-07-10 04:35', 12),
('2020-08-07 10:02', 10),
('2020-08-31 23:40', 2),
('2020-05-29 15:59', 2),
('2021-01-08 22:48', 3),
('2020-03-07 19:30', 1),
('2020-08-25 12:27', 5),
('2020-06-01 23:34', 8),
('2021-01-06 20:37', 9),
('2020-10-22 17:33', 10),
('2020-03-23 14:48', 13),
('2020-05-27 17:00', 13),
('2020-12-25 04:18', 2),
('2020-02-23 02:32', 4),
('2020-05-26 07:51', 4),
('2020-09-17 16:52', 5),
('2020-08-04 10:42', 6),
('2020-04-10 14:10', 6),
('2020-12-29 01:31', 2),
('2020-07-09 20:17', 1),
('2020-03-29 21:17', 3),
('2020-06-30 16:28', 10),
('2020-12-17 15:38', 8),
('2020-11-22 22:36', 7),
('2020-02-19 13:29', 10),
('2020-10-29 04:55', 11),
('2020-09-12 11:07', 12),
('2020-03-19 18:21', 10),
('2020-03-19 18:21', 2),
('2020-12-24 21:31', 1),
('2020-03-31 19:29', 2),
('2020-07-05 18:28', 4),
('2020-07-15 16:24', 6),
('2020-12-24 18:19', 9),
('2020-09-22 17:26', 12),
('2020-09-06 19:52', 11),
('2020-04-16 05:08', 5),
('2020-06-24 01:18', 5),
('2020-11-22 22:17', 2),
('2020-07-06 16:01', 10),
('2021-01-02 15:56', 13),
('2020-10-24 04:33', 5),
('2020-11-20 23:42', 2),
('2020-03-01 08:51', 12),
('2020-03-31 05:48', 6),
('2020-06-02 22:38', 8),
('2020-11-03 15:13', 8),
('2020-10-27 06:16', 7),
('2020-12-09 21:47', 9),
('2021-04-21 08:42', 10),
('2021-02-16 03:15', 1),
('2021-03-13 20:56', 2),
('2021-01-03 14:18', 2),
('2021-04-06 14:18', 2),
('2021-03-24 02:55', 3),
('2021-01-14 22:45', 4),
('2021-01-17 15:19', 7),
('2021-01-07 11:22', 10),
('2021-01-02 09:34', 12),
('2021-04-20 21:37', 11),
('2021-03-28 23:58', 10),
('2021-04-09 18:48', 9),
('2021-02-28 02:01', 7),
('2021-04-03 08:10', 8),
('2021-02-03 14:26', 10),
('2021-01-07 16:52', 11),
('2021-04-18 09:47', 13),
('2021-02-27 18:13', 12),
('2021-02-06 09:39', 9),
('2021-01-07 00:21', 4),
('2021-03-29 04:27', 5),
('2021-03-14 07:43', 6),
('2021-01-24 02:06', 2),
('2021-01-13 11:08', 10),
('2022-11-24 15:53:55', 4),
('2023-01-03 01:29:02', 6),
('2023-01-14 13:13:41', 3),
('2023-03-31 12:55:06', 13),
('2023-01-11 16:16:24', 11),
('2023-01-31 13:36:50', 2),
('2022-12-03 12:30:49', 5),
('2022-11-24 15:53:55', 7),
('2023-02-27 23:25:01', 9),
('2023-04-29 16:16:39', 10),
('2023-01-03 16:20:50', 4),
('2022-12-22 21:35:18', 1),
('2023-03-29 08:10:19', 2),
('2022-12-13 19:40:05', 6),
('2023-03-28 20:45:27', 10),
('2023-04-30 23:29:17', 4),
('2023-02-17 16:43:25', 7),
('2023-02-17 07:57:30', 9),
('2023-03-22 03:09:55', 2);


INSERT INTO Orders (ord_datetime, ord_an) 
SELECT ord_datetime, ord_an FROM #TempOrders ORDER BY ord_datetime;