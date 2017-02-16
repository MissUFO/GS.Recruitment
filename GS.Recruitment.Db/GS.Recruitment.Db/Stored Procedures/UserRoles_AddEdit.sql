CREATE PROCEDURE [auth].[UserRoles_AddEdit]
		@UserID	uniqueidentifier
	   ,@RoleType INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM auth.UserRoles WHERE UserID = @UserID

	INSERT INTO auth.UserRoles
			([UserID]
			,[RoleId]
			,[CreatedOn])
	VALUES
			( @UserID
			,(SELECT top(1) r.Id FROM auth.Roles AS r WHERE r.RoleType=@RoleType)
			, GETDATE());

END