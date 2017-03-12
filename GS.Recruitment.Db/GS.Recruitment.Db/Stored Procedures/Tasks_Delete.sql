CREATE PROCEDURE [process].[Tasks_Delete]
		@Id	uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [process].[Tasks]
      WHERE Id = @Id
END