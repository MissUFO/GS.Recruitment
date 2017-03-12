CREATE PROCEDURE [msg].[Notifications_List]
				 @UserId UNIQUEIDENTIFIER = null
				,@IsReceived bit = 0
				,@Xml XML output
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml = (SELECT (SELECT nfc.Id
							  ,nfc.Subject
							  ,nfc.Message
							  ,nfc.NotificationType
							  ,nfc.UserId
							  ,usr.Login as UserLogin
							  ,nfc.EntityId
							  ,nfc.EntityType
							  ,nfc.CreatedOn
							  ,nfc.IsReceived
							  ,nfc.ReceivedOn
						FROM msg.Notifications AS nfc
							LEFT OUTER JOIN auth.Users usr ON usr.Id = @UserId
						WHERE (nfc.UserId = @UserId OR @UserId IS NULL ) and IsReceived = @IsReceived
						ORDER BY nfc.CreatedOn DESC
					FOR XML RAW('Notification'), TYPE)
				FOR XML PATH('Notifications'),TYPE)
END