CREATE PROCEDURE [msg].[Dashboard_Get_Recruiter]
				 @UserId UNIQUEIDENTIFIER
				,@Xml XML OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml =  (SELECT
						(SELECT
								 (SELECT count(Id) FROM [process].[Tasks] WHERE UserToId = @UserId) as Total
								,(SELECT count(Id) FROM [process].[Tasks] WHERE UserToId = @UserId and TaskStatus = 0) as New
								,(SELECT count(Id) FROM [process].[Tasks] WHERE UserToId = @UserId and TaskStatus = 1) as InProg
								,(SELECT count(Id) FROM [process].[Tasks] WHERE UserToId = @UserId and TaskStatus = 2) as Completed
								,(SELECT count(Id) FROM [process].[Tasks] WHERE UserToId = @UserId and TaskStatus = 3) as Closed
						  FOR XML RAW('DashboardTasks'), TYPE)
						,(SELECT
								 (SELECT count(Id) FROM [process].[Assignments] WHERE UserToId = @UserId) as Total
								,(SELECT count(Id) FROM [process].[Assignments] WHERE UserToId = @UserId and AssignmentStatus = 0) as New
								,(SELECT count(Id) FROM [process].[Assignments] WHERE UserToId = @UserId and AssignmentStatus = 1) as InProg
								,(SELECT count(Id) FROM [process].[Assignments] WHERE UserToId = @UserId and AssignmentStatus = 2) as Completed
								,(SELECT count(Id) FROM [process].[Assignments] WHERE UserToId = @UserId and AssignmentStatus = 3) as Closed
						  FOR XML RAW('DashboardAssignments'), TYPE)
						,(SELECT
								 (SELECT count(Id) FROM [msg].[Notifications] WHERE UserId = @UserId) as Total
								,(SELECT count(Id) FROM [msg].[Notifications] WHERE UserId = @UserId) as My
								,(SELECT count(Id) FROM [msg].[Notifications] WHERE UserId = @UserId and IsReceived = 1) as TotalReceived
								,(SELECT count(Id) FROM [msg].[Notifications] WHERE UserId = @UserId and IsReceived = 0) as TotalNotReceived
						  FOR XML RAW('DashboardNotifications'), TYPE)
						
					FOR XML PATH('Dashboard'),TYPE)
						
END