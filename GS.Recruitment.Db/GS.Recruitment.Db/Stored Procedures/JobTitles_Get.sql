CREATE PROCEDURE [enum].[JobTitles_Get]
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
						FROM enum.JobTitles
						WHERE Id=@Id
						ORDER BY Name ASC
						FOR XML RAW('DictionaryItem'), TYPE)
				FOR XML PATH('DictionaryItems'),TYPE)
END