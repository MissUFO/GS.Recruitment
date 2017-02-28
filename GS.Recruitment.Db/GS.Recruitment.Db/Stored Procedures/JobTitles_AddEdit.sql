CREATE PROCEDURE [enum].[JobTitles_AddEdit]
				  @Id UNIQUEIDENTIFIER
				 ,@Name NVARCHAR(255)
				 ,@ParentId UNIQUEIDENTIFIER = null
				 ,@OutputId uniqueidentifier OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	 IF EXISTS(SELECT 1 FROM [enum].[JobTitles] WHERE Id = @Id)
	BEGIN

        UPDATE [enum].[JobTitles]
		   SET [Name] = @Name
			  ,[ModifiedOn] = GETDATE()
	        WHERE Id = @Id

			SET @OutputId = @Id 
	END
    ELSE
    BEGIN

			SET @OutputId = NEWID();

			INSERT INTO [enum].[JobTitles]
			   ([Id]
			   ,[Name]
			   ,[CreatedOn]
			   ,[ModifiedOn])	
			 VALUES
				   (@OutputId
				   ,@Name
				   ,GETDATE()
				   ,GETDATE())

    END
						
END