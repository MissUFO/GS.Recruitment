/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT [auth].[Users] ([Id], [Login], [Password], [FirstName], [LastName], [UserStatus], [CreatedOn], [ModifiedOn], [LastLoginOn], [LastPasswordChangedOn], [FailedPasswordAttemptCount], [CreatedBy], [ModifiedBy]) VALUES (N'0d6e5c08-af39-4fbb-9401-674e01172c2f', N'admin@local.com', N'admin', NULL, NULL, 1, CAST(N'2017-02-12T19:43:49.987' AS DateTime), CAST(N'2017-02-17T21:26:19.710' AS DateTime), CAST(N'2017-02-25T20:56:46.740' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [auth].[Users] ([Id], [Login], [Password], [FirstName], [LastName], [UserStatus], [CreatedOn], [ModifiedOn], [LastLoginOn], [LastPasswordChangedOn], [FailedPasswordAttemptCount], [CreatedBy], [ModifiedBy]) VALUES (N'6e12698f-f440-4c28-919f-f75fa73c1dea', N'recruiter@local.com', N'recruiter', NULL, NULL, 1, CAST(N'2017-02-12T19:44:34.720' AS DateTime), CAST(N'2017-02-12T19:44:34.720' AS DateTime), CAST(N'2017-02-25T20:57:20.857' AS DateTime), NULL, 0, NULL, NULL)
GO
INSERT [auth].[Roles] ([Id], [Name], [RoleType]) VALUES (N'739b79f1-dab3-4612-b30b-011e9b076f9c', N'Recruiter', 1)
GO
INSERT [auth].[Roles] ([Id], [Name], [RoleType]) VALUES (N'19ab3f16-4110-4a49-b884-718a7398bc69', N'Administrator', 0)
GO
INSERT [auth].[Roles] ([Id], [Name], [RoleType]) VALUES (N'fb9dd609-cf9d-4e93-8887-9b5e415938a7', N'Candidate', 2)
GO
INSERT [auth].[UserRoles] ([Id], [UserId], [RoleId], [CreatedOn], [CreatedBy]) VALUES (N'7168b32c-0be0-4a7e-94fc-711c99fc75df', N'0d6e5c08-af39-4fbb-9401-674e01172c2f', N'19ab3f16-4110-4a49-b884-718a7398bc69', CAST(N'2017-02-12T19:46:52.443' AS DateTime), NULL)
GO
INSERT [auth].[UserRoles] ([Id], [UserId], [RoleId], [CreatedOn], [CreatedBy]) VALUES (N'e61415d0-29f1-4f0c-bd33-b3131594e2d1', N'6e12698f-f440-4c28-919f-f75fa73c1dea', N'739b79f1-dab3-4612-b30b-011e9b076f9c', CAST(N'2017-02-12T19:47:09.913' AS DateTime), NULL)

