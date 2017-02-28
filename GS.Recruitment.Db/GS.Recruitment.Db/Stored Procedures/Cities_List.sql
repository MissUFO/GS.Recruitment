CREATE PROCEDURE [enum].[Cities_List]
				 @ParentId UNIQUEIDENTIFIER = null
				,@Xml XML output
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml = (SELECT (SELECT	   [Id]
								  ,[Name]
								  ,[CountryId] as ParentId
								  ,[CreatedOn]
								  ,[ModifiedOn]
								  ,[CreatedBy]
								  ,[ModifiedBy]
						FROM enum.Cities
						WHERE CountryId=@ParentId OR @ParentId IS NULL
						ORDER BY Name ASC
						FOR XML RAW('DictionaryItem'), TYPE)
				FOR XML PATH('DictionaryItems'),TYPE)
END