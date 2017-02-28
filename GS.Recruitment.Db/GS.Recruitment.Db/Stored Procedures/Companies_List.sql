CREATE PROCEDURE [enum].[Companies_List]
				 @ParentId UNIQUEIDENTIFIER = null
				,@Xml XML output
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml = (SELECT (SELECT	   [Id]
								  ,[Name]
								  ,[IndustryId] as ParentId
								  ,[CreatedOn]
								  ,[ModifiedOn]
								  ,[CreatedBy]
								  ,[ModifiedBy]
						FROM enum.Companies
						WHERE IndustryId=@ParentId OR @ParentId IS NULL
						ORDER BY Name ASC
						FOR XML RAW('DictionaryItem'), TYPE)
				FOR XML PATH('DictionaryItems'),TYPE)
END