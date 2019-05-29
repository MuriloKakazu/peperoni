CREATE TABLE [Account]
(
	[Id] GUID NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(128) NOT NULL, 
    [Phone] VARCHAR(11) NOT NULL, 
	[StreetName] VARCHAR(256) NOT NULL,
    [StreetNumber] INT NOT NULL, 
    [PostalCode] CHAR(8) NOT NULL,
	[ComplementaryAddress] VARCHAR(1024) NULL
)
