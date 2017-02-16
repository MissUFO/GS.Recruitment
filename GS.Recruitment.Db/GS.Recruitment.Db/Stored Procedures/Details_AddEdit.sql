CREATE PROCEDURE [contact].[Details_AddEdit]
				@ContactDetailId uniqueidentifier
			   ,@FirstName nvarchar(100)
			   ,@LastName nvarchar(100)
			   ,@MiddleName nvarchar(100) = null
			   ,@Address nvarchar(1024) = null
			   ,@PostCode nvarchar(50) = null
			   ,@CityId uniqueidentifier = null
			   ,@CountryId uniqueidentifier = null
			   ,@Birthday datetime = null
			   ,@CreatedOn datetime = null
			   ,@ModifiedOn datetime = null
			   ,@CreatedBy uniqueidentifier = null
			   ,@ModifiedBy uniqueidentifier = null
			   ,@OutputId uniqueidentifier OUTPUT
				
AS
BEGIN
		
    IF EXISTS(SELECT 1 FROM [contact].[Details] WHERE Id = @ContactDetailId)
	BEGIN

        UPDATE [contact].[Details]
		   SET [FirstName] = @FirstName
			  ,[LastName] = @LastName
			  ,[MiddleName] = @MiddleName
			  ,[Address] = @Address
			  ,[PostCode] = @PostCode
			  ,[CityId] = @CityId
			  ,[CountryId] = @CountryId
			  ,[Birthday] = @Birthday
			  ,[ModifiedOn] = ISNULL(@ModifiedOn, GETDATE())
			  ,[ModifiedBy] = @ModifiedBy
	        WHERE Id = @ContactDetailId

			SET @OutputId = @ContactDetailId 
	END
    ELSE
    BEGIN

			SET @OutputId = NEWID();

			INSERT INTO [contact].[Details]
			   ([Id]
			   ,[FirstName]
			   ,[LastName]
			   ,[MiddleName]
			   ,[Address]
			   ,[PostCode]
			   ,[CityId]
			   ,[CountryId]
			   ,[Birthday]
			   ,[CreatedOn]
			   ,[ModifiedOn]
			   ,[CreatedBy]
			   ,[ModifiedBy])	
			 VALUES
				   (@OutputId
				   ,@FirstName
				   ,@LastName
				   ,@MiddleName
				   ,@Address
				   ,@PostCode
				   ,@CityId
				   ,@CountryId
				   ,@Birthday
				   ,GETDATE()
				   ,GETDATE()
				   ,@CreatedBy
				   ,@ModifiedBy)

    END

END