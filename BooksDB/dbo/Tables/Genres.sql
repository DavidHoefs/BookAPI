CREATE TABLE [dbo].[Genres]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Genre] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(500) NULL, 
    [ModifyDate] DATETIME NOT NULL DEFAULT getdate()
)
