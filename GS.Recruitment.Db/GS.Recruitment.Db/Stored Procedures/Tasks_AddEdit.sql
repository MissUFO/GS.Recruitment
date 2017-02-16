CREATE PROCEDURE [process].[Tasks_AddEdit]	
				   @Id uniqueidentifier
				  ,@Title nvarchar(1024)
				  ,@Description nvarchar(max)
				  ,@UserFromId uniqueidentifier
				  ,@UserToId uniqueidentifier 
				  ,@TaskStatus tinyint = 0
				  ,@CreatedOn datetime 
				  ,@ModifiedOn datetime 
				  ,@CreatedBy uniqueidentifier = null
				  ,@ModifiedBy uniqueidentifier = null				
AS
BEGIN

DECLARE @return_value			 INT
	
    IF EXISTS(SELECT 1 FROM process.Tasks WHERE Id = @Id)
	BEGIN

		-- Update task if exists
	
        UPDATE [process].[Tasks]
            SET	   [Title] = @Title
				  ,[Description] = @Description
				  ,[UserFromId] = @UserFromId
				  ,[UserToId] = @UserToId
				  ,[TaskStatus] = @TaskStatus
				  ,[ModifiedOn] = ISNULL(@ModifiedOn, GETDATE())
				  ,[ModifiedBy] = @ModifiedBy
	        WHERE Id = @Id
	    
	END
    ELSE
    BEGIN

		-- Create a new task
	
		SET @Id = NEWID();

		INSERT INTO [process].[Tasks]
           ([Id]
           ,[Title]
           ,[Description]
           ,[UserFromId]
           ,[UserToId]
           ,[TaskStatus]
           ,[CreatedOn]
           ,[ModifiedOn]
           ,[CreatedBy]
           ,[ModifiedBy])
     VALUES
           (@Id
           ,@Title
           ,@Description
           ,@UserFromId
           ,@UserToId
           ,@TaskStatus
           ,ISNULL(@CreatedOn, GETDATE())
           ,ISNULL(@ModifiedOn, GETDATE())
           ,@CreatedBy
           ,@ModifiedBy)

    END

END