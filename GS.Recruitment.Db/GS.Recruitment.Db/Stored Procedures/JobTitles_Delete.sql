﻿CREATE PROCEDURE [enum].[JobTitles_Delete]
				 @Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [enum].[JobTitles] WHERE Id=@Id
						
END