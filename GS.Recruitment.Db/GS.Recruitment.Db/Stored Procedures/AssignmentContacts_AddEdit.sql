CREATE PROCEDURE [process].[AssignmentContacts_AddEdit]	
				    @Id				uniqueidentifier
				   ,@AssignmentId	uniqueidentifier 
				   ,@ContactId		uniqueidentifier 
				   ,@AssignmentContactStatus   tinyint = 0
				   ,@Comment		nvarchar(max)
				   ,@CreatedOn		datetime
				   ,@ModifiedOn		datetime
				   ,@CreatedBy		uniqueidentifier = null
				   ,@ModifiedBy		uniqueidentifier = null			
AS
BEGIN

DECLARE @return_value			 INT
	
    IF EXISTS(SELECT 1 FROM process.AssignmentContacts WHERE Id = @Id OR (AssignmentId=@AssignmentId and ContactId=@ContactId))
	BEGIN

		-- Update assignment contact if exists
	
        UPDATE [process].[AssignmentContacts]
            SET	   [AssignmentContactStatus] = @AssignmentContactStatus
				  ,[Comment] = @Comment
				  ,[ModifiedOn] = ISNULL(@ModifiedOn, GETDATE())
				  ,[CreatedBy] = @CreatedBy
				  ,[ModifiedBy] = @ModifiedBy
	        WHERE Id = @Id  OR (AssignmentId=@AssignmentId and ContactId=@ContactId)
	    
	END
    ELSE
    BEGIN

		-- Create a new assignment contact
	
		SET @Id = NEWID();

		INSERT INTO [process].[AssignmentContacts]
           ([Id]
           ,[AssignmentId]
           ,[ContactId]
           ,[AssignmentContactStatus]
           ,[Comment]
           ,[CreatedOn]
           ,[ModifiedOn]
           ,[CreatedBy]
           ,[ModifiedBy])
     VALUES
           (@Id
           ,@AssignmentId
           ,@ContactId
           ,@AssignmentContactStatus
           ,@Comment
           ,ISNULL(@CreatedOn, GETDATE())
           ,ISNULL(@ModifiedOn, GETDATE())
           ,@CreatedBy
           ,@ModifiedBy)


    END

END