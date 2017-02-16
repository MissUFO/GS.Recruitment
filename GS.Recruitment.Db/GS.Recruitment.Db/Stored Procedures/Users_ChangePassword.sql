CREATE PROCEDURE auth.Users_ChangePassword 
		@UserID	   uniqueidentifier
	   ,@Password  NVARCHAR(255)
AS
BEGIN
   SET NOCOUNT ON;

   UPDATE auth.Users
   SET [LastPasswordChangedOn] = GETDATE()
      ,[Password] = @Password
	WHERE Id = @UserID

END