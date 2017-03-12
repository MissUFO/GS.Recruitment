CREATE PROCEDURE [process].[Assignments_Delete]
		@Id	uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [process].[Assignments]
      WHERE Id = @Id
END