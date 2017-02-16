CREATE PROCEDURE [auth].[Users_Login]
				@Login	    NVARCHAR(255)
			  , @Password	NVARCHAR(255)
			  , @Xml XML output
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ID UNIQUEIDENTIFIER

	SELECT @ID = usr.Id
	  FROM auth.Users as usr
	 WHERE usr.[Login] = @Login and usr.[Password] = @Password and usr.UserStatus = 1
	 
	IF(@ID IS NULL)
	BEGIN
		RETURN -1
	END

    UPDATE auth.Users
		SET LastLoginOn = GETDATE()
	WHERE Id = @ID

	SET @Xml = (SELECT (SELECT	 usr.Id 
								,cnt.FirstName
								,cnt.LastName
								,usr.Login
								,usr.Password
								,usr.LastLoginOn
								,usr.LastPasswordChangedOn
								,usr.FailedPasswordAttemptCount
								,usr.CreatedOn
								,usr.ModifiedOn
								,usr.UserStatus
								,(SELECT	 
									 roles.RoleId
									,roles.UserId
									,[role].RoleType
									,[role].[Name]
									,roles.CreatedOn
									FROM auth.UserRoles AS roles
										LEFT JOIN auth.Roles [role] ON [role].Id = roles.RoleId 
									WHERE roles.UserId = usr.Id
									FOR XML RAW('UserRole'), TYPE) 
						FROM auth.Users AS usr
							LEFT OUTER JOIN contact.UserDetails ud ON ud.UserId = usr.Id 
							LEFT OUTER JOIN contact.Details cnt ON cnt.Id = ud.ContactDetailId 
						WHERE usr.Id=@ID
						
						FOR XML RAW('User'), TYPE)
				FOR XML PATH('Users'),TYPE)

END