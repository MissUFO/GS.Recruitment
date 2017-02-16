CREATE PROCEDURE [settings].[UserSettings_AddEdit]	
                  @UserId					UNIQUEIDENTIFIER
				 ,@SystemNotifications		bit
				 ,@EmailNotifications		bit
				
AS
BEGIN
		
    IF EXISTS(SELECT 1 FROM settings.UserSettings WHERE UserId = @UserId)
	BEGIN

		-- Update user settings if exists
	
        UPDATE settings.UserSettings
            SET [SystemNotifications] = @SystemNotifications
			   ,[EmailNotifications] = @EmailNotifications
               ,[ModifiedOn] = GETDATE()
	        WHERE UserId= @UserId
	    
	END
    ELSE
    BEGIN

		-- Create a new user setting
	
		INSERT INTO settings.UserSettings
           ([Id]
           ,[UserId]
           ,[SystemNotifications]
		   ,[EmailNotifications]
           ,[ModifiedOn])
		VALUES
           (NEWID()
		   ,@UserId
           ,@SystemNotifications
           ,@EmailNotifications
		   ,GETDATE());

    END
	
END