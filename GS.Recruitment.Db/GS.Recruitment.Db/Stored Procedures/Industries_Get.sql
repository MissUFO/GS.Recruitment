CREATE PROCEDURE [enum].[Industries_Get]
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
						FROM enum.Industries
						WHERE Id=@Id
						ORDER BY Name ASC
						FOR XML RAW('DictionaryItem'), TYPE)
				FOR XML PATH('DictionaryItems'),TYPE)
END