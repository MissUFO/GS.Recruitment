CREATE PROCEDURE [process].[Assignments_List_Task]
				 @TaskId UNIQUEIDENTIFIER
				,@Xml XML OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml =  (SELECT(SELECT	 
						 assignment.Id
						,ta.TaskId
						,assignment.Title
						,assignment.Description
						,assignment.UserFromId
						,a_usrfrom.Login as UserFromLogin
						,assignment.UserToId
						,a_usrto.Login as UserToLogin
						,assignment.AssignmentStatus
						,assignment.CreatedOn
						,assignment.ModifiedOn

						,(SELECT(SELECT	 
									 detail.Id
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
								FROM [process].[AssignmentContacts] AS ac
									LEFT OUTER JOIN contact.Details detail ON detail.Id = ac.ContactId 
									LEFT OUTER JOIN enum.Cities d_city ON d_city.Id = detail.CityId 
									LEFT OUTER JOIN enum.Countries d_country ON d_country.Id = detail.CountryId
								WHERE ac.AssignmentId = ta.AssignmentId
							FOR XML RAW('Contact'), TYPE)
						FOR XML PATH('Contacts'),TYPE)

						FROM [process].[TaskAssignments] AS ta
							--LEFT OUTER JOIN process.Tasks task ON task.Id = ta.TaskId 
							LEFT OUTER JOIN process.Assignments assignment ON assignment.Id = ta.AssignmentId 
							LEFT OUTER JOIN auth.Users a_usrfrom ON a_usrfrom.Id = assignment.UserFromId 
							LEFT OUTER JOIN auth.Users a_usrto ON a_usrto.Id = assignment.UserToId 
						WHERE ta.TaskId = @TaskId
						ORDER BY ta.CreatedOn desc
						FOR XML RAW('Assignment'), TYPE)
					FOR XML PATH('Assignments'),TYPE)
						
END