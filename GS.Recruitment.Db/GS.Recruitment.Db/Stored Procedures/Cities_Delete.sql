﻿CREATE PROCEDURE [enum].[Cities_Delete]
				 @Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [enum].[Cities] WHERE Id=@Id
						
END