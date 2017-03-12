CREATE PROCEDURE [log].[Exceptions_AddEdit]
		   @Id uniqueidentifier = null
		  ,@Message nvarchar(1024) 
		  ,@Exception  nvarchar(max) = null
		  ,@Location   nvarchar(1024) = null
		  ,@ExceptionType tinyint = 0
		  ,@ExceptionOn  datetime = null
		  ,@UserId uniqueidentifier = null
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM [log].[Exceptions] WHERE Message = @Message and ExceptionType = @ExceptionType and Location = @Location and UserId = @UserId)
	BEGIN

	-- Update if exists
	   UPDATE [log].[Exceptions]
	   SET [Exception] = @Exception
		  ,[ExceptionOn] = getdate()
	   WHERE Message = @Message and ExceptionType = @ExceptionType and Location = @Location and UserId = @UserId

	END
    ELSE
    BEGIN

		-- Create a new record
		SET @Id = NEWID();

		INSERT INTO [log].[Exceptions]
			   ([Id]
			   ,[Message]
			   ,[Exception]
			   ,[Location]
			   ,[ExceptionType]
			   ,[ExceptionOn]
			   ,[UserId])
		 VALUES
			   (@Id
			   ,@Message
			   ,@Exception
			   ,@Location
			   ,@ExceptionType
			   ,@ExceptionOn
			   ,@UserId)

	END
END