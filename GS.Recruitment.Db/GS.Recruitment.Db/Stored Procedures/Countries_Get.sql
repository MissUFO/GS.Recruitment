﻿CREATE PROCEDURE [enum].[Countries_Get]
				 @Id UNIQUEIDENTIFIER
				,@Xml XML output
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml = (SELECT (SELECT	   [Id]
								  ,[Name]
								  ,[CreatedOn]
								  ,[ModifiedOn]
								  ,[CreatedBy]
								  ,[ModifiedBy]
						FROM enum.Countries
						WHERE Id=@Id
						ORDER BY Name ASC
						FOR XML RAW('DictionaryItem'), TYPE)
				FOR XML PATH('DictionaryItems'),TYPE)
END