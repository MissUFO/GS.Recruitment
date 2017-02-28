CREATE PROCEDURE [enum].[JobTitles_List]
				 @ParentId UNIQUEIDENTIFIER = null
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
						FROM enum.JobTitles
						ORDER BY Name ASC
						FOR XML RAW('DictionaryItem'), TYPE)
				FOR XML PATH('DictionaryItems'),TYPE)
END