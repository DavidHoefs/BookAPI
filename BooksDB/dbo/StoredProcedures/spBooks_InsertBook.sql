CREATE PROCEDURE [dbo].[spBooks_InsertBook]
	@BookId VARCHAR(126),
	@Title VARCHAR(200),
	@AuthorFirstName VARCHAR(50),
	@AuthorLastName VARCHAR(50),
	@Genre VARCHAR(50),
	@Price MONEY,
	@PublishDate DATETIME,
	@Description VARCHAR(3500)
AS
BEGIN
	BEGIN TRY
		SET NOCOUNT ON;
		DECLARE @TranStarted INT = 0,
				@AuthorId INT;


		IF(@@TRANCOUNT = 0) BEGIN
			BEGIN TRAN;
			SET @TranStarted = 1;
		END	


		-- Check if author already exists.
		IF NOT EXISTS (SELECT Id FROM dbo.Authors a WHERE a.FirstName = @AuthorFirstName AND a.LastName = @AuthorLastName) BEGIN
			INSERT INTO dbo.Authors
			(
				FirstName,
				LastName,
				ModifyDate
			)
			VALUES 
			(
				@AuthorFirstName,
				@AuthorLastName,
				GETDATE()
			);

			SET @AuthorId = SCOPE_IDENTITY();

			IF(@@ERROR <> 0) GOTO Failed;
		END	
		ELSE BEGIN
			SELECT @AuthorId = Id
			FROM dbo.Authors a 
			WHERE a.FirstName = @AuthorFirstName
			AND a.LastName = @AuthorLastName;
		END	

		-- Insert new book record
		BEGIN
			INSERT INTO dbo.Books
			(
				BookId,
				AuthorId,
				Title,
				Description,
				PublishDate,
				Genre,
				Price,
				ModifyDate
			)
			VALUES 
			(
				@BookId,
				@AuthorId,
				@Title,
				@Description,
				@PublishDate,
				@Genre,
				@Price,
				GETDATE()
			);

			IF(@@ERROR <> 0) GOTO Failed;
		END
		
		-- Commit Transaction 
		IF(@TranStarted = 1) BEGIN
			COMMIT TRAN;
			SET @TranStarted = 0;
		END	
		SELECT 0;

		Failed:
		BEGIN
			IF(@TranStarted = 1) BEGIN
				ROLLBACK TRAN;
				SET @TranStarted = 0;
			END	

			SELECT 99;
		END	

	END TRY
	BEGIN CATCH
		PRINT 'ERROR'
		IF(@TranStarted = 1) BEGIN
				ROLLBACK TRAN;
				SET @TranStarted = 0;
			END	

			SELECT 99;
	END CATCH
END	
