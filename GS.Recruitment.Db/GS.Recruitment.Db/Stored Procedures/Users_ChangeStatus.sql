CREATE PROCEDURE auth.Users_ChangeStatus
		@UserID	   uniqueidentifier
	   ,@StatusID  INT
AS
BEGIN
	SET NOCOUNT ON;

   UPDATE auth.Users
   SET [ModifiedOn] = GETDATE()
      ,[UserStatus] = @StatusID
	WHERE Id = @UserID

END