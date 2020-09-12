CREATE TABLE [dbo].[Credit]
(
	[ID] INT PRIMARY KEY NOT NULL,
	[SessionID] INT NULL,
	[DisciplineID] INT NULL,
	[ExaminerID] INT NULL,
	[Date] DATE NOT NULL
)