CREATE PROCEDURE [log].[Exceptions_Delete]
				 @Id  UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [log].[Exceptions] WHERE Id = @Id
	
END