CREATE PROCEDURE [enum].[Cities_AddEdit]
				  @Id UNIQUEIDENTIFIER
				 ,@Name NVARCHAR(255)
				 ,@ParentId UNIQUEIDENTIFIER = null
				 ,@OutputId uniqueidentifier OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	 IF EXISTS(SELECT 1 FROM [enum].[Cities] WHERE Id = @Id)
	BEGIN

        UPDATE [enum].[Cities]
		   SET [Name] = @Name
			  ,[CountryId] = @ParentId
			  ,[ModifiedOn] = GETDATE()
	        WHERE Id = @Id

			SET @OutputId = @Id 
	END
    ELSE
    BEGIN

			SET @OutputId = NEWID();

			INSERT INTO [enum].[Cities]
			   ([Id]
			   ,[Name]
			   ,[CountryId]
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