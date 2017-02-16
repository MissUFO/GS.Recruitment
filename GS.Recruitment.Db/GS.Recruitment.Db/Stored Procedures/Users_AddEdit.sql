CREATE PROCEDURE [auth].[Users_AddEdit]	
                  @UserID	          UNIQUEIDENTIFIER
	             ,@FirstName          NVARCHAR(255)
                 ,@LastName           NVARCHAR(255)
                 ,@Login              NVARCHAR(255)
				 ,@Password           NVARCHAR(50)
                 ,@UserStatus         INT
	             ,@RoleType           INT
				
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

DECLARE @return_value			 INT

BEGIN TRAN
   BEGIN TRY
		
    IF EXISTS(SELECT 1 FROM auth.Users WHERE Id = @UserID)
	BEGIN

		-- Update user if exists
	
        UPDATE auth.Users
            SET [Login] = @Login
			   ,[FirstName] = @FirstName
			   ,[LastName] = @LastName
               ,[ModifiedOn] = GETDATE()
	           ,[UserStatus] = @UserStatus
	        WHERE Id = @UserID
	    
	END
    ELSE
    BEGIN

		-- Create a new user
	
		SET @UserID = NEWID();

		INSERT INTO auth.Users
           ([Id]
           ,[Login]
           ,[Password]
		   ,[FirstName]
		   ,[LastName]
		   ,[LastPasswordChangedOn]
           ,[FailedPasswordAttemptCount]
           ,[CreatedOn]
           ,[ModifiedOn]
           ,[UserStatus])
		VALUES
           (@UserID
           ,@Login
           ,@Password
		   ,@FirstName
		   ,@LastName
		   ,GETDATE()
           ,0
           ,GETDATE()
           ,GETDATE()
           ,@UserStatus);

    END
	
	-- if it's candidate
	IF @RoleType = 2
	BEGIN

		-- Create or update contact detail
		DECLARE	@OutputId				 uniqueidentifier
		DECLARE	@ContactDetailId		 uniqueidentifier

		IF EXISTS(SELECT 1 FROM [contact].[UserDetails] WHERE [UserId]=@UserID)
			BEGIN
			    
					SET @ContactDetailId = (SELECT top(1) ContactDetailId FROM [contact].[UserDetails] WHERE [UserId]=@UserID)
		
					EXEC [contact].[Details_AddEdit] @ContactDetailId, @FirstName, @LastName,
						@OutputId = @OutputId OUTPUT
			END
			ELSE
			BEGIN
					EXEC  [contact].[Details_AddEdit] @ContactDetailId, @FirstName, @LastName,
						@OutputId = @OutputId OUTPUT

					-- Associate the contact detail to user

					INSERT INTO [contact].[UserDetails] ([Id], [UserId] ,[ContactDetailId] ,[CreatedOn],[ModifiedOn])
					VALUES (NEWID(), @UserID, @OutputId, GETDATE(), GETDATE())
			END

		-- Associate role to user
	   
		EXEC  [auth].[UserRoles_AddEdit] @UserID, @RoleType

	END

    COMMIT TRAN;		
   END TRY
   BEGIN CATCH
		ROLLBACK TRAN;

		RETURN @return_value;
   END CATCH
END