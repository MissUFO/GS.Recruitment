CREATE PROCEDURE [auth].[Users_List_Recruiters]
				@Xml XML output
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml = (SELECT (SELECT	 usr.Id 
								,usr.FirstName
								,usr.LastName
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
									FOR XML RAW('UserRole'), TYPE) 
						FROM auth.Users AS usr
							LEFT JOIN auth.UserRoles [roles] ON [roles].UserId = usr.Id 
							LEFT JOIN auth.Roles [role] ON [role].Id = roles.RoleId 
						WHERE [role].RoleType = 1
						ORDER BY usr.FirstName, usr.LastName asc
						FOR XML RAW('User'), TYPE)
				FOR XML PATH('Users'),TYPE)
END