﻿CREATE TABLE [dbo].[Student]
(
	[ID] INT PRIMARY KEY NOT NULL,
	[FullName] NVARCHAR(max) NOT NULL,
	[Gender] NVARCHAR(10) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[GroupID] INT NULL
)