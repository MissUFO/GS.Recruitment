CREATE PROCEDURE [process].[Assignments_AddEdit]	
				    @TaskId uniqueidentifier
				   ,@Id uniqueidentifier
				   ,@Title nvarchar(1024)
				   ,@Description nvarchar(max)
				   ,@StartDate datetime = null
				   ,@EndDate datetime = null
				   ,@UserFromId uniqueidentifier
				   ,@UserToId uniqueidentifier
				   ,@AssignmentStatus tinyint = 0
				   ,@CreatedOn datetime
				   ,@ModifiedOn datetime
				   ,@CreatedBy uniqueidentifier = null
				   ,@ModifiedBy uniqueidentifier = null			
AS
BEGIN

DECLARE @return_value			 INT
	
    IF EXISTS(SELECT 1 FROM process.Assignments WHERE Id = @Id)
	BEGIN

		-- Update assignments if exists
	
        UPDATE [process].[Assignments]
            SET	   [Title] = @Title
				  ,[Description] = @Description
				  ,[StartDate] =  ISNULL(@StartDate, GETDATE())
				  ,[EndDate] = @EndDate
				  ,[UserFromId] = @UserFromId
				  ,[UserToId] = @UserToId
				  ,[AssignmentStatus] = @AssignmentStatus
				  ,[ModifiedOn] = ISNULL(@ModifiedOn, GETDATE())
				  ,[ModifiedBy] = @ModifiedBy
	        WHERE Id = @Id
	    
	END
    ELSE
    BEGIN

		-- Create a new assignment
	
		SET @Id = NEWID();

		INSERT INTO [process].[Assignments]
          ( [Id]
           ,[Title]
           ,[Description]
		   ,[StartDate]
		   ,[EndDate]
           ,[UserFromId]
           ,[UserToId]
           ,[AssignmentStatus]
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
           ,@AssignmentStatus
           ,ISNULL(@CreatedOn, GETDATE())
           ,ISNULL(@ModifiedOn, GETDATE())
           ,@CreatedBy
           ,@ModifiedBy)

	INSERT INTO [process].[TaskAssignments] ([Id], [TaskId], [AssignmentId], [CreatedOn], [CreatedBy])
    VALUES (NEWID(), @TaskId, @Id, GETDATE(), @CreatedBy)

    END

END