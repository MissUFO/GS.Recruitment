CREATE PROCEDURE [auth].[Users_Delete]
		@UserId	uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [auth].[Users]
      WHERE Id = @UserId
END