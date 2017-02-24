CREATE PROCEDURE [msg].[Dashboard_Get_Admin]
				 @UserId UNIQUEIDENTIFIER
				,@Xml XML OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml =  (SELECT
						(SELECT
								 (SELECT count(Id) FROM [contact].[Details]) as Total
						  FOR XML RAW('DashboardContacts'), TYPE)
						,(SELECT
								  (SELECT count(Id) FROM [auth].[Users]) as Total
								 ,(SELECT count(Id) FROM [auth].[Users] WHERE UserStatus=1 ) as Active
								 ,(SELECT count(Id) FROM [auth].[Users] WHERE UserStatus=0 ) as Locked
						  FOR XML RAW('DashboardUsers'), TYPE)
					    ,(SELECT
								 (SELECT count(Id) FROM [process].[Tasks]) as Total
								,(SELECT count(Id) FROM [process].[Tasks] WHERE TaskStatus = 0) as New
								,(SELECT count(Id) FROM [process].[Tasks] WHERE TaskStatus = 1) as InProg
								,(SELECT count(Id) FROM [process].[Tasks] WHERE TaskStatus = 2) as Completed
								,(SELECT count(Id) FROM [process].[Tasks] WHERE TaskStatus = 3) as Closed
						  FOR XML RAW('DashboardTasks'), TYPE)
						,(SELECT
								 (SELECT count(Id) FROM [process].[Assignments] ) as Total
								,(SELECT count(Id) FROM [process].[Assignments] WHERE AssignmentStatus = 0) as New
								,(SELECT count(Id) FROM [process].[Assignments] WHERE AssignmentStatus = 1) as InProg
								,(SELECT count(Id) FROM [process].[Assignments] WHERE AssignmentStatus = 2) as Completed
								,(SELECT count(Id) FROM [process].[Assignments] WHERE AssignmentStatus = 3) as Closed
						  FOR XML RAW('DashboardAssignments'), TYPE)
						,(SELECT
								 (SELECT count(Id) FROM [msg].[Notifications]) as Total
								,(SELECT count(Id) FROM [msg].[Notifications] WHERE UserId = @UserId) as My
								,(SELECT count(Id) FROM [msg].[Notifications] WHERE IsReceived = 1) as TotalReceived
								,(SELECT count(Id) FROM [msg].[Notifications] WHERE IsReceived = 0) as TotalNotReceived
						  FOR XML RAW('DashboardNotifications'), TYPE)
						
					FOR XML PATH('Dashboard'),TYPE)
						
END