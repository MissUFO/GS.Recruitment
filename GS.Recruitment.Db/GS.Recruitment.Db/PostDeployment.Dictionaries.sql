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

INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7143', N'Professional, Scientific, Technical Services', CAST(N'2017-02-28T16:11:14.700' AS DateTime), CAST(N'2017-02-28T16:11:14.700' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7243', N'Administrative and Support Services', CAST(N'2017-02-28T16:11:42.483' AS DateTime), CAST(N'2017-02-28T16:11:42.483' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7343', N'Public Administration and Safety', CAST(N'2017-02-28T16:11:54.517' AS DateTime), CAST(N'2017-02-28T16:11:54.517' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7443', N'Mining', CAST(N'2017-02-28T16:07:25.290' AS DateTime), CAST(N'2017-02-28T16:07:25.290' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7444', N'Manufacturing', CAST(N'2017-02-28T16:07:40.820' AS DateTime), CAST(N'2017-02-28T16:07:40.820' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7445', N'Electricity, Gas, Water, Waste Services', CAST(N'2017-02-28T16:08:10.370' AS DateTime), CAST(N'2017-02-28T16:08:10.370' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7446', N'Construction', CAST(N'2017-02-28T16:08:31.480' AS DateTime), CAST(N'2017-02-28T16:08:31.480' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7447', N'Wholesale Trade', CAST(N'2017-02-28T16:08:59.870' AS DateTime), CAST(N'2017-02-28T16:08:59.870' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7448', N'Retail Trade', CAST(N'2017-02-28T16:09:11.887' AS DateTime), CAST(N'2017-02-28T16:09:11.887' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7449', N'Accommodation and Food Services', CAST(N'2017-02-28T16:09:39.510' AS DateTime), CAST(N'2017-02-28T16:09:39.510' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7453', N'Transport, Postal and Warehousing', CAST(N'2017-02-28T16:09:53.763' AS DateTime), CAST(N'2017-02-28T16:09:53.763' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7463', N'Information Media and Telecommunications', CAST(N'2017-02-28T16:10:12.590' AS DateTime), CAST(N'2017-02-28T16:10:12.590' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7473', N'Financial and Insurance Services', CAST(N'2017-02-28T16:10:29.420' AS DateTime), CAST(N'2017-02-28T16:10:29.420' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7483', N'Rental, Hiring and Real Estate Services', CAST(N'2017-02-28T16:10:59.250' AS DateTime), CAST(N'2017-02-28T16:10:59.250' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7543', N'Education and Training', CAST(N'2017-02-28T16:12:21.500' AS DateTime), CAST(N'2017-02-28T16:12:21.500' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7643', N'Health Care and Social Assistance', CAST(N'2017-02-28T16:12:39.377' AS DateTime), CAST(N'2017-02-28T16:12:39.377' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Industries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'fa6d6a24-256e-4857-992b-6b030f8a7743', N'Arts and Recreation Services', CAST(N'2017-02-28T16:12:50.750' AS DateTime), CAST(N'2017-02-28T16:12:50.750' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Companies] ([Id], [IndustryId], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'00dbffed-26b0-4fde-92d5-1b0a6a23e9ab', N'fa6d6a24-256e-4857-992b-6b030f8a7473', N'Bank of America', CAST(N'2017-02-28T16:33:31.830' AS DateTime), CAST(N'2017-02-28T16:33:31.830' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Companies] ([Id], [IndustryId], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'2292837d-9586-4510-a213-21b21efd4789', N'fa6d6a24-256e-4857-992b-6b030f8a7473', N'NatWest', CAST(N'2017-02-28T16:35:26.333' AS DateTime), CAST(N'2017-02-28T16:35:26.333' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Companies] ([Id], [IndustryId], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'70d1bb1c-fcb9-4f73-936d-947271e652dc', N'fa6d6a24-256e-4857-992b-6b030f8a7473', N'HSBC', CAST(N'2017-02-28T16:33:00.203' AS DateTime), CAST(N'2017-02-28T16:33:00.203' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Companies] ([Id], [IndustryId], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'9daf4fce-6327-41ee-be63-aaa0bebd5e03', N'fa6d6a24-256e-4857-992b-6b030f8a7473', N'Barclays', CAST(N'2017-02-28T16:34:37.190' AS DateTime), CAST(N'2017-02-28T16:34:37.190' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Countries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'a2e45fa6-e5c2-4d93-9e66-81aae4345da7', N'United States', CAST(N'2017-02-26T18:28:04.547' AS DateTime), CAST(N'2017-02-26T18:28:04.547' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Countries] ([Id], [Name], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'85e22293-7c5a-455a-8da4-c2e44a853bf1', N'United Kingdom', CAST(N'2017-02-26T18:27:30.603' AS DateTime), CAST(N'2017-02-26T18:27:30.603' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Cities] ([Id], [Name], [CountryId], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'38853c34-4120-422a-9eb6-5748dd97111e', N'New York', N'a2e45fa6-e5c2-4d93-9e66-81aae4345da7', CAST(N'2017-02-26T18:29:42.550' AS DateTime), CAST(N'2017-02-26T18:29:42.550' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Cities] ([Id], [Name], [CountryId], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'4652e994-f588-46cb-b3cd-7f1ecd314c2b', N'Manchester', N'85e22293-7c5a-455a-8da4-c2e44a853bf1', CAST(N'2017-02-26T18:29:09.653' AS DateTime), CAST(N'2017-02-26T18:29:09.653' AS DateTime), NULL, NULL)
GO
INSERT [enum].[Cities] ([Id], [Name], [CountryId], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (N'62beef25-43c6-468a-96e7-c30479f2a472', N'London', N'85e22293-7c5a-455a-8da4-c2e44a853bf1', CAST(N'2017-02-26T18:28:49.737' AS DateTime), CAST(N'2017-02-26T18:28:49.737' AS DateTime), NULL, NULL)
GO

