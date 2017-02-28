CREATE PROCEDURE [process].[Assignments_List_UserTo]
				 @UserToId UNIQUEIDENTIFIER
				,@Xml XML OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml =  (SELECT(SELECT	 
						 assignment.Id
						,assignment.Number
						,ta.TaskId
						,assignment.Title
						,assignment.Description
						,assignment.StartDate
						,assignment.EndDate
						,assignment.UserFromId
						,a_usrfrom.Login as UserFromLogin
						,assignment.UserToId
						,a_usrto.Login as UserToLogin
						,assignment.AssignmentStatus
						,assignment.CreatedOn
						,assignment.ModifiedOn
						,(SELECT task.Id
							  ,task.Number
							  ,task.Title
							  ,task.Description
							  ,task.StartDate
							  ,task.EndDate
							  ,task.UserFromId
							  --,userfrom.Login as UserFromLogin
							  ,task.UserToId
							  --,userto.Login as UserToLogin
							  ,task.TaskStatus
							  ,task.CreatedOn
							  ,task.ModifiedOn
							  ,task.CreatedBy
							  ,task.ModifiedBy
						 FOR XML RAW('Task'), TYPE)
						 FROM [process].[TaskAssignments] AS ta
							LEFT OUTER JOIN process.Tasks task ON task.Id = ta.TaskId 
							LEFT OUTER JOIN process.Assignments assignment ON assignment.Id = ta.AssignmentId 
							LEFT OUTER JOIN auth.Users a_usrfrom ON a_usrfrom.Id = assignment.UserFromId 
							LEFT OUTER JOIN auth.Users a_usrto ON a_usrto.Id = assignment.UserToId 
						 WHERE assignment.UserToId = @UserToId
						 ORDER BY ta.CreatedOn desc
						 FOR XML RAW('Assignment'), TYPE)
					 FOR XML PATH('Assignments'),TYPE)
						
END