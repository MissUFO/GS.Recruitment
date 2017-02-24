CREATE TABLE [auth].[Users] (
    [Id]                         UNIQUEIDENTIFIER NOT NULL,
    [Login]                      NVARCHAR (255)   NOT NULL,
    [Password]                   NVARCHAR (255)   NOT NULL,
    [FirstName]                  NVARCHAR (255)   NULL,
    [LastName]                   NVARCHAR (255)   NULL,
    [UserStatus]                 INT              CONSTRAINT [DF_Users_UserStatus] DEFAULT ((0)) NOT NULL,
    [CreatedOn]                  DATETIME         CONSTRAINT [DF_Users_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]                 DATETIME         CONSTRAINT [DF_Users_Modified] DEFAULT (getdate()) NOT NULL,
    [LastLoginOn]                DATETIME         NULL,
    [LastPasswordChangedOn]      DATETIME         NULL,
    [FailedPasswordAttemptCount] TINYINT          CONSTRAINT [DF_Users_FailedPasswordAttemptCount] DEFAULT ((0)) NOT NULL,
    [CreatedBy]                  UNIQUEIDENTIFIER NULL,
    [ModifiedBy]                 UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK__Users__3214EC078DD2AB22] PRIMARY KEY CLUSTERED ([Id] ASC)
);








GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Locked = 0,
   Active = 1', @level0type = N'SCHEMA', @level0name = N'auth', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'UserStatus';





