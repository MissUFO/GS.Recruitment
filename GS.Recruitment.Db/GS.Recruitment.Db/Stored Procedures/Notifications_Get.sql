﻿CREATE PROCEDURE [msg].[Notifications_Get]
				 @Id  UNIQUEIDENTIFIER
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
							LEFT OUTER JOIN auth.Users usr ON usr.Id = nfc.UserId
						WHERE nfc.Id = @Id
						ORDER BY nfc.CreatedOn DESC
					FOR XML RAW('Notification'), TYPE)
				FOR XML PATH('Notifications'),TYPE)
END