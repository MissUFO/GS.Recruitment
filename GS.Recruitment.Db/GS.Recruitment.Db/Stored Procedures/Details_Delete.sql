CREATE PROCEDURE [contact].[Details_Delete]
		@Id	uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [contact].[Details]
      WHERE Id = @Id
END