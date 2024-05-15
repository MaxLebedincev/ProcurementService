INSERT INTO [dbo].[TypesBallroomDance]
    ([Name])
VALUES
    ('Вальс'),
	('Фокстрот'),
	('Танго'),
	('Ча-ча-ча'),
	('Румба'),
	('Самба'),
	('Джайв'),
	('Пасодобль'),
	('Стандарт'),
	('Латина')
	
	
INSERT INTO [dbo].[RussiaTrainersBallroomDance]
	([TypeBallroomDanceId]
	,[FirstName]
	,[LastName]
	,[MiddleName])
VALUES
	(1, 'Александрова','Ольга','Ивановна'),
	(1, 'Попов','Станислав','Александрович'),
	(1, 'Шалкевич','Борис','Владимирович'),
	(2, 'Попова','Татьяна','Сергеевна'),
	(3, 'Симаков','Сергей','Александрович'),
	(4, 'Васнецова','Елена','Петровна'),
	(5, 'Овчинников','Дмитрий','Владимирович'),
	(6, 'Карамышева','Анна','Викторовна'),
	(7, 'Чернышев','Александр','Александрович'),
	(7, 'Танина','Ирина','Сергеевна')
	
	
INSERT INTO [dbo].[DanceGroups]
    ([RussiaTrainerBallroomDanceId]
    ,[Name]
    ,[Created])
VALUES
    (1, 'Ансамбль танца \"Русские узоры\"','01.01.1995'),
	(2, 'Танцевальный коллектив \"Элегия\"','01.01.2000'),
	(3, 'Студенческий танцевальный ансамбль \"Степ\"','01.01.1987'),
	(4, 'Детский хореографический ансамбль \"Вихрь\"','01.01.1993'),
	(5, 'Школа танцев \"Harmony\"','01.01.2003'),
	(6, 'Юношеский танцевальный коллектив \"Арман\"','01.01.1998'),
	(7, 'Клуб танца \"Меридиан\"','01.01.2010'),
	(NULL, 'Танцевальный ансамбль \"Империя танца\"','01.01.2005'),
	(NULL, 'Хореографический ансамбль \"Цветик-семицветик\"','01.01.1980'),
	(NULL, 'Детский танцевальный коллектив \"Звезды\"','01.01.1997')
	
	
INSERT INTO [dbo].[Files]
    ([Name]
    ,[Size])
VALUES
    ('sunset_paradise.png', 265),
	('magical_dreams.png', 34),
	('secret_garden.png', 69),
	('neon_night.png', 228),
	('winter_wonderland.png', 146),
	('enchanted_forest.png', 42),
	('golden_hour.png', 420),
	('ocean_breeze.png', 616),
	('starry_sky.png', 177013),
	('crystal_clear.png', 12122012)
	
	
INSERT INTO [dbo].[MembersDanceGroup]
    ([DanceGroupId]
    ,[GuidPhotoFile]
    ,[FirstName]
    ,[LastName]
    ,[MiddleName]
    ,[City]
    ,[Category]
    ,[Score])
VALUES
	(1, NULL, 'Михаил', 'Михайлов', 'Михайлович', 'Москва', '3а', 1), 
	(2, NULL, 'Николай', 'Николаев', 'Николаевич', 'Санкт-Петербург', '4а', 2), 
	(3, NULL, 'Елена', 'Елисеева', 'Ефимовна', 'Казань', '2а', 3), 
	(4, NULL, 'Анна', 'Андреева', 'Антоновна', 'Пермь', '1а', 4), 
	(5, NULL, 'Иван', 'Иванов', 'Ильич', 'Владимир', '5а', 5), 
	(6, NULL, 'Мария', 'Маркова', 'Маратовна', 'Самара', '2б', 6), 
	(6, NULL, 'Сергей', 'Соколов', 'Семёнович', 'Саратов', '3б', 7),
	(8, NULL, 'Александр', 'Александров', 'Алексеевич', 'Волгоград', '4в', 97), 
	(8, NULL, 'Татьяна', 'Тарасова', 'Тимуровна', 'Уфа', '1б', 98),
	(10, NULL, 'Андрей', 'Андреев', 'Анатольевич', 'Красноярск', '5б', 52)


INSERT [dbo].[UserRoles] 
	([Name]) 
VALUES 
	(N'admin')

INSERT [dbo].[Users] 
	([IdUserRole], 
	[Login], 
	[Email], 
	[Password], 
	[Created], 
	[Updated]) 
VALUES 
	(1, N'Kira', N'Kira@email.com', N'8On8WBVO4/96H1HaMsc2hw7eYlGRLnz2WrqEnuL12R7TCwHLTC2WUXyxf4W9h+8gZY/w0b7hs7Z8NEYL/UnO7g==', CAST(N'2024-03-15T01:52:03.9154364' AS DateTime2), NULL),
	(1, N'lololo', N'tuturu@mail.com', N'SCVrePTPJpUQK926yVE57Bm95TLApqYJTvTb0gE1sUmsFV62y1FST18LvsTASRwBEJXTVyiZxBAHGsnJsfOcmg==', CAST(N'2024-03-28T23:11:07.3574760' AS DateTime2), CAST(N'2024-03-28T23:11:07.3574760' AS DateTime2))
