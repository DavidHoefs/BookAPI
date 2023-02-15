CREATE PROCEDURE [dbo].[spBooks_GetBooks]
	--@Id INT,
	--@BookId INT,
	--@FirstName VARCHAR(50),
	--@LastName VARCHAR(50),
	--@Title NVARCHAR(150),
	--@Genre NVARCHAR(50),
	--@Price MONEY,
	--@PublishDate DATETIME,
	--@Description NVARCHAR(3000)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT b.id,
		   b.BookId,
		   a.FirstName AS AuthorFirstName,
		   a.LastName AS AuthorLastName,
		   b.Title,
		   b.Genre,
		   b.Price,
		   b.PublishDate,
		   b.ModifyDate,
		   b.Description
	FROM dbo.Books b
	INNER JOIN dbo.Authors a ON b.AuthorId = a.Id;
	
END
