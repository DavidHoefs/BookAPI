CREATE PROCEDURE [dbo].[spBooks_GetBooks]
	@Id INT,
	@BookId INT,
	@FirstName VARCHAR(50),
	@LastName VARCHAR(50),
	@Title NVARCHAR(150),
	@Genre NVARCHAR(50),
	@Price MONEY,
	@PublishDate DATETIME,
	@Description NVARCHAR(3000)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.Books
	
END
