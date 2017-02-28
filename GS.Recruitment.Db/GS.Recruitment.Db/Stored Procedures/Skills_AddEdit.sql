CREATE PROCEDURE [enum].[Skills_AddEdit]
				  @Id UNIQUEIDENTIFIER
				 ,@Name NVARCHAR(255)
				 ,@ParentId UNIQUEIDENTIFIER = null
				 ,@OutputId uniqueidentifier OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	 IF EXISTS(SELECT 1 FROM [enum].[Skills] WHERE Id = @Id)
	BEGIN

        UPDATE [enum].[Skills]
		   SET [Name] = @Name
			  ,[ModifiedOn] = GETDATE()
	        WHERE Id = @Id

			SET @OutputId = @Id 
	END
    ELSE
    BEGIN

			SET @OutputId = NEWID();

			INSERT INTO [enum].[Skills]
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