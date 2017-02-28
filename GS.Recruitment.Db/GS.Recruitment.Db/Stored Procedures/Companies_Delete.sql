CREATE PROCEDURE [enum].[Companies_Delete]
				 @Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [enum].[Companies] WHERE Id=@Id
						
END