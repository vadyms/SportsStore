﻿Use SportsStore

CREATE TABLE [dbo].[Products]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(500) NOT NULL, 
    [Category] NVARCHAR(50) NOT NULL, 
    [Price] DECIMAL(16, 2) NOT NULL
)
