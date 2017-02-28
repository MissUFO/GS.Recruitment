CREATE PROCEDURE [enum].[Countries_Delete]
				 @Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [enum].[Countries] WHERE Id=@Id
						
END