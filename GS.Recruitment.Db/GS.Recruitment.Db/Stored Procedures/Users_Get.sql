CREATE PROCEDURE [auth].[Users_Get]
		@UserID	uniqueidentifier
	   ,@Xml XML output
AS
BEGIN
	SET NOCOUNT ON;

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
										LEFT OUTER JOIN auth.Roles [role] ON [role].Id = roles.RoleId 
									WHERE roles.UserId = usr.Id
									FOR XML RAW('UserRole'), TYPE) 
						FROM auth.Users AS usr
							LEFT OUTER JOIN contact.UserDetails ud ON ud.UserId = usr.Id 
							LEFT OUTER JOIN contact.Details cnt ON cnt.Id = ud.ContactDetailId 
						WHERE usr.Id = @UserID
						
						FOR XML RAW('User'), TYPE)
				FOR XML PATH('Users'),TYPE)
END
