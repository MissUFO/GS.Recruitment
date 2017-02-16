CREATE PROCEDURE auth.UserRoles_Get
		@UserID	uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * from auth.UserRoles Where UserID=@UserID
END