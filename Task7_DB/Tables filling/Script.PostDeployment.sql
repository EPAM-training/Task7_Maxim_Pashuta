INSERT [dbo].[Specialty] ([ID], [Name]) 
VALUES (1, N'Computer science and programming technologies')

INSERT [dbo].[Group] ([ID], [SpecialtyID], [Name]) 
VALUES (1, 1, N'IP-22')

INSERT [dbo].[Session] ([ID], [GroupID], [SemesterNumber]) 
VALUES (1, 1, 1),
       (2, 1, 2)

INSERT [dbo].[Examiner] ([ID], [FullName]) 
VALUES (1, N'Maksimova Sofya Arsentievna'),
       (2, N'Mikhailov Artyom Leonidovich'),
       (3, N'Leontiev Egor Platonovich'),
       (4, N'Komarov Tikhon Makarovich'),
       (5, N'Zorin Nikita Timofeevich'),
       (6, N'Smirnov Lev Lukich'),
       (7, N'Bobrov Pavel Bogdanovich')

INSERT [dbo].[Student] ([ID], [FullName], [Gender], [Birthdate], [GroupID]) 
VALUES (1, N'Famov Maxim Gennadievich', N'Male', CAST(N'2000-06-06' AS Date), 1),
       (2, N'Herons Viktor Vladimirovich', N'Male', CAST(N'2001-05-19' AS Date), 1),
       (3, N'Avseeva Eva Eleseevna', N'Woman', CAST(N'2001-04-18' AS Date), 1)

INSERT [dbo].[Discipline] ([ID], [Name]) 
VALUES (1, N'Math'),
       (2, N'OOP'),
       (3, N'MMA'),
       (4, N'History'),
       (5, N'OAIP')

INSERT INTO [dbo].[Credit] ([ID], [SessionID], [DisciplineID], [Date], [ExaminerID]) 
VALUES (1, 1, 4, CAST(N'2019-05-22' AS Date), 1),
	   (2, 1, 5, CAST(N'2019-05-25' AS Date), 2),
	   (3, 2, 3, CAST(N'2019-05-24' AS Date), 3),
	   (4, 2, 5, CAST(N'2019-05-27' AS Date), 4)

INSERT [dbo].[Exam] ([ID], [SessionID], [DisciplineID], [Date], [ExaminerID]) 
VALUES (1, 1, 2, CAST(N'2019-06-14' AS Date), 5),
       (2, 1, 1, CAST(N'2019-06-18' AS Date), 2),
       (3, 1, 3, CAST(N'2019-06-22' AS Date), 6),
       (4, 2, 4, CAST(N'2019-06-12' AS Date), 4),
       (5, 2, 1, CAST(N'2019-06-15' AS Date), 7),
       (6, 2, 2, CAST(N'2019-06-19' AS Date), 1)

INSERT [dbo].[CreditResult] ([ID], [StudentID], [CreditID], [Result]) 
VALUES (1, 1, 1, 1),
	   (2, 1, 2, 0),
	   (3, 2, 1, 1),
       (4, 2, 2, 1),
       (5, 3, 1, 0),
       (6, 3, 2, 1),
       (7, 1, 3, 1),
       (8, 1, 4, 1),
       (9, 2, 3, 1),
       (10, 2, 4, 0),
       (11, 3, 3, 0),
       (12, 3, 4, 0)

INSERT [dbo].[ExamResult] ([ID], [StudentID], [ExamID], [Result]) 
VALUES (1, 1, 1, 6),
       (2, 1, 2, 8),
       (3, 1, 3, 5),
       (4, 2, 1, 2),
       (5, 2, 2, 2),
       (6, 2, 3, 2),
       (7, 3, 1, 2),
       (8, 3, 2, 2),
       (9, 3, 3, 2),
       (10, 1, 4, 5),
       (11, 1, 5, 6),
       (12, 1, 6, 9),
       (13, 2, 4, 7),
       (14, 2, 5, 6),
       (15, 2, 6, 8),
       (16, 3, 4, 5),
       (17, 3, 5, 4),
       (18, 3, 6, 7)

