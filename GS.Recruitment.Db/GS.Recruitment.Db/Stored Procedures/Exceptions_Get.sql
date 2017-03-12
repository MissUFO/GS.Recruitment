CREATE PROCEDURE [log].[Exceptions_Get]
				 @Id  UNIQUEIDENTIFIER
				,@Xml XML output
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml = (SELECT (SELECT  exc.Id
							   ,exc.Message
							   ,exc.Exception
							   ,exc.Location
							   ,exc.ExceptionType
							   ,exc.ExceptionOn
							   ,exc.UserId
							   ,usr.Login as UserName
						FROM log.Exceptions AS exc
							LEFT OUTER JOIN auth.Users usr ON usr.Id = exc.UserId
						WHERE exc.Id = @Id
						ORDER BY exc.ExceptionOn DESC
					FOR XML RAW('Exception'), TYPE)
				FOR XML PATH('Exceptions'),TYPE)
END