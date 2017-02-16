CREATE PROCEDURE [settings].[UserSettings_Get]
		@UserId	uniqueidentifier
	   ,@Xml XML output
AS
BEGIN
	SET NOCOUNT ON;

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