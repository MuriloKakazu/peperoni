CREATE TABLE [dbo].[Account]
(
	[Id] CHAR(32) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(128) NOT NULL, 
    [Phone] VARCHAR(9) NOT NULL, 
    [StreetName] VARCHAR(64) NOT NULL, 
    [StreetNumber] INT NOT NULL, 
    [PostalCode] CHAR(8) NOT NULL 
)
