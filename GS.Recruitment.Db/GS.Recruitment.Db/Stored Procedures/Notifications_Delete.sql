CREATE PROCEDURE [msg].[Notifications_Delete]
				 @Id  UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM msg.Notifications WHERE Id = @Id
	
END