CREATE TABLE [dbo].[Authors]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [ModifyDate] DATETIME NULL DEFAULT getdate()
)
