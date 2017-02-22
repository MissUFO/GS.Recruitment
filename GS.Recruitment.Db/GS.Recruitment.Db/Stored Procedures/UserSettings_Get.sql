CREATE PROCEDURE [settings].[UserSettings_Get]
		@UserId	uniqueidentifier
	   ,@Xml XML output
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM settings.UserSettings WHERE UserId = @UserId)
	BEGIN
		SET @Xml = (SELECT (SELECT	top(1) setting.Id
									  ,setting.UserId
									  ,setting.SystemNotifications
									  ,setting.EmailNotifications
									  ,setting.ModifiedOn
								FROM settings.UserSettings AS setting
								WHERE setting.UserId = @UserID
								ORDER BY setting.ModifiedOn DESC
							FOR XML RAW('UserSetting'), TYPE)
					FOR XML PATH('UserSettings'),TYPE)
	END
    ELSE
    BEGIN
		SET @Xml = (SELECT (SELECT   @UserId as UserId
									,'1' as SystemNotifications
									,'1' as EmailNotifications
							FOR XML RAW('UserSetting'), TYPE)
					FOR XML PATH('UserSettings'),TYPE)
	END
END