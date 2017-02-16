CREATE PROCEDURE [msg].[Notifications_AddEdit]	
					@Id			uniqueidentifier
				   ,@Subject	nvarchar(255)
				   ,@Message	nvarchar(max)
				   ,@NotificationType int
				   ,@UserId		uniqueidentifier
				   ,@EntityId	uniqueidentifier
				   ,@EntityType int
				   ,@CreatedOn	datetime
				   ,@IsReceived bit
				   ,@ReceivedOn datetime
				
AS
BEGIN

DECLARE @return_value			 INT
	
    IF EXISTS(SELECT 1 FROM msg.Notifications WHERE Id = @Id)
	BEGIN

		-- Update notification if exists
	
        UPDATE msg.Notifications
            SET	   [Subject] = @Subject
				  ,[Message] = @Message
				  ,[NotificationType] = @NotificationType
				  ,[UserId] = @UserId
				  ,[EntityId] = @EntityId
				  ,[EntityType] = @EntityType
				  ,[IsReceived] = @IsReceived
				  ,[ReceivedOn] = ISNULL(@ReceivedOn, GETDATE())
	        WHERE Id = @Id
	    
	END
    ELSE
    BEGIN

		-- Create a new notification
	
		SET @Id = NEWID();

		INSERT INTO [msg].[Notifications]
           ([Id]
           ,[Subject]
           ,[Message]
           ,[NotificationType]
           ,[UserId]
           ,[EntityId]
           ,[EntityType]
           ,[CreatedOn]
           ,[IsReceived]
           ,[ReceivedOn])
		VALUES
           (@Id
           ,@Subject
           ,@Message
           ,@NotificationType
           ,@UserId
           ,@EntityId
           ,@EntityType
           ,ISNULL(@CreatedOn, GETDATE())
           ,@IsReceived
           ,@ReceivedOn)

    END

END