CREATE PROCEDURE [enum].[Industries_Delete]
				 @Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [enum].[Industries] WHERE Id=@Id
						
END