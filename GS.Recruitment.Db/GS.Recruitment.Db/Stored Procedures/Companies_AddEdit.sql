CREATE PROCEDURE [enum].[Companies_AddEdit]
				  @Id UNIQUEIDENTIFIER
				 ,@Name NVARCHAR(255)
				 ,@ParentId UNIQUEIDENTIFIER = null
				 ,@OutputId uniqueidentifier OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	 IF EXISTS(SELECT 1 FROM [enum].[Companies] WHERE Id = @Id)
	BEGIN

        UPDATE [enum].[Companies]
		   SET [Name] = @Name
			  ,[IndustryId] = @ParentId
			  ,[ModifiedOn] = GETDATE()
	        WHERE Id = @Id

			SET @OutputId = @Id 
	END
    ELSE
    BEGIN

			SET @OutputId = NEWID();

			INSERT INTO [enum].[Companies]
			   ([Id]
			   ,[Name]
			   ,[IndustryId]
			   ,[CreatedOn]
			   ,[ModifiedOn])	
			 VALUES
				   (@OutputId
				   ,@Name
				   ,@ParentId
				   ,GETDATE()
				   ,GETDATE())

    END
						
END