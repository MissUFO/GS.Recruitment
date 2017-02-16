CREATE PROCEDURE [contact].[Details_Get]
				 @ContactDetailId	uniqueidentifier
				,@Xml XML output
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml = (SELECT (SELECT detail.Id
							  ,detail.FirstName
							  ,detail.LastName
							  ,detail.MiddleName
							  ,detail.Address
							  ,detail.PostCode
							  ,detail.CityId
							  ,d_city.Name as CityName
							  ,detail.CountryId
							  ,d_country.Name as CountryName
							  ,detail.Birthday
							  ,detail.CreatedOn
							  ,detail.ModifiedOn
							  ,detail.CreatedBy
							  ,detail.ModifiedBy
							  ,(SELECT(SELECT	 
									 email.Id
									,email.Email
									,email.IsPreferred
									FROM [contact].[Emails] AS email
									WHERE email.ContactDetailId = detail.Id
									FOR XML RAW('Email'), TYPE)
								FOR XML PATH('Emails'),TYPE)
							  ,(SELECT(SELECT	 
									 phone.Id
									,phone.Phone
									,phone.IsPreferred
									FROM [contact].[Phones] AS phone
									WHERE phone.ContactDetailId = detail.Id
									FOR XML RAW('Phone'), TYPE)
								FOR XML PATH('Phones'),TYPE)
							  ,(SELECT(SELECT	 
									 attachment.Id
									,attachment.FileName
									,attachment.AttachmentType
									,attachment.CreatedOn
									,attachment.ModifiedOn
									FROM [contact].[Attachments] AS attachment
									WHERE attachment.ContactDetailId = detail.Id
									FOR XML RAW('Attachment'), TYPE)
								FOR XML PATH('Attachments'),TYPE)
							,(SELECT(SELECT	 
									 education.Id
									,education.Name
									,education.Description
									,education.CityId
									,ed_cities.Name as CityName
									,education.DateFrom
									,education.DateTo
									,education.IsCurrent
									,education.IsGraduated
									,education.GraduatedAs
									,education.CreatedOn
									,education.ModifiedOn
									FROM [contact].[Educations] AS education
										LEFT OUTER JOIN enum.Cities ed_cities ON ed_cities.Id = education.CityId 
									WHERE education.ContactDetailId = detail.Id
									FOR XML RAW('Education'), TYPE)
								FOR XML PATH('Educations'),TYPE)
							,(SELECT(SELECT	 
									 experience.Id
									,experience.CompanyId
									,ex_company.Name as CompanyName
									,experience.JobTitleId
									,ex_jobtitle.Name as JobTitle
									,experience.JobDescription
									,experience.CityId
									,ex_cities.Name as CityName
									,experience.DateFrom
									,experience.DateTo
									,experience.IsCurrent
									,experience.CreatedOn
									,experience.ModifiedOn
									FROM [contact].[Experiences] AS experience
										LEFT OUTER JOIN enum.JobTitles ex_jobtitle ON ex_jobtitle.Id = experience.JobTitleId 
										LEFT OUTER JOIN enum.Cities ex_cities ON ex_cities.Id = experience.CityId 
										LEFT OUTER JOIN enum.Companies ex_company ON ex_company.Id = experience.CompanyId
									WHERE experience.ContactDetailId = detail.Id
									FOR XML RAW('Experience'), TYPE)
								FOR XML PATH('Experiences'),TYPE)
							,(SELECT(SELECT	 
									 preferences.Id
									,preferences.SalaryFrom
									,preferences.SalaryTo
									,preferences.JobTitleId
									,e_jobtitle.Name as JobTitle
									,preferences.CityId
									,e_cities.Name as CityName
									,e_country.Name as CountryName
									,preferences.CountryId
									,preferences.IsReadyForRelocation
									,preferences.Description
									,preferences.LastContactDate
									,preferences.LastContactedBy
									FROM [contact].[JobPreferences] AS preferences
										LEFT OUTER JOIN enum.JobTitles e_jobtitle ON e_jobtitle.Id = preferences.JobTitleId 
										LEFT OUTER JOIN enum.Cities e_cities ON e_cities.Id = preferences.CityId 
										LEFT OUTER JOIN enum.Countries e_country ON e_country.Id = preferences.CountryId
									WHERE preferences.ContactDetailId = detail.Id
									FOR XML RAW('JobPreference'), TYPE)
								FOR XML PATH('JobPreferences'),TYPE)
							,(SELECT(SELECT	 
									 skill.Id
									,skill.SkillId
									,e_skill.Name as SkillName
									,skill.CreatedOn
									,skill.ModifiedOn
									FROM [contact].[Skills] AS skill
										LEFT OUTER JOIN enum.Skills e_skill ON e_skill.Id = skill.SkillId 
									WHERE skill.ContactDetailId = detail.Id
									FOR XML RAW('Skill'), TYPE)
								FOR XML PATH('Skills'),TYPE)
							,(SELECT(SELECT	 
									 social.Id
									,social.UserName
									,social.ProfileUrl
									,social.SocialNetworkType
									,social.CreatedOn
									,social.ModifiedOn
									FROM [contact].[SocialNetworks] AS social
									WHERE social.ContactDetailId = detail.Id
									FOR XML RAW('SocialNetwork'), TYPE)
								FOR XML PATH('SocialNetworks'),TYPE)
							,(SELECT(SELECT	 
									 usr.Id
									,usr.UserId
									,a_usr.Login
									,a_usr.Password
									,a_usr.UserStatus
									,role.RoleType
									,a_usr.LastLoginOn
									,a_usr.CreatedOn
									,a_usr.ModifiedOn
									FROM [contact].[UserDetails] AS usr
										LEFT OUTER JOIN auth.Users a_usr ON a_usr.Id = usr.UserId 
										LEFT OUTER JOIN auth.UserRoles u_role ON u_role.UserId = usr.UserId
										LEFT OUTER JOIN auth.Roles role ON role.Id = u_role.RoleId 
									WHERE usr.ContactDetailId = detail.Id
									FOR XML RAW('UserDetail'), TYPE)
								FOR XML PATH('UserDetails'),TYPE)

						  FROM [contact].[Details] AS detail
										LEFT OUTER JOIN enum.Cities d_city ON d_city.Id = detail.CityId 
										LEFT OUTER JOIN enum.Countries d_country ON d_country.Id = detail.CountryId
						  WHERE detail.Id = @ContactDetailId
						  FOR XML RAW('Contact'), TYPE)
				FOR XML PATH('Contacts'),TYPE)
									
END