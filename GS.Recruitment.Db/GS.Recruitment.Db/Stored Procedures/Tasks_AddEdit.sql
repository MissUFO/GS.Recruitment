CREATE PROCEDURE [process].[Tasks_AddEdit]	
				   @Id uniqueidentifier
				  ,@Title nvarchar(1024)
				  ,@Description nvarchar(max)
				  ,@StartDate datetime = null
				  ,@EndDate datetime = null
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
				  ,[StartDate] = ISNULL(@StartDate, GETDATE())
				  ,[EndDate] = @EndDate
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
		   ,[StartDate]
		   ,[EndDate]
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
		   ,ISNULL(@StartDate, GETDATE())
		   ,@EndDate
           ,@UserFromId
           ,@UserToId
           ,@TaskStatus
           ,ISNULL(@CreatedOn, GETDATE())
           ,ISNULL(@ModifiedOn, GETDATE())
           ,@CreatedBy
           ,@ModifiedBy)


		   -- Create Notification item
	EXEC [msg].[Notifications_AddEdit]
		@Id = NEWID,
		@Subject = @Title,
		@Message = @Description,
		@NotificationType = 0,
		@UserId = @UserToId,
		@EntityId = @Id,
		@EntityType = 0,
		@CreatedOn = GETDATE,
		@IsReceived = 0

    END

END