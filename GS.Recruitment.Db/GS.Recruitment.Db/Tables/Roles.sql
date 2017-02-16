CREATE TABLE [auth].[Roles] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Name]     NVARCHAR (255)   NOT NULL,
    [RoleType] TINYINT          CONSTRAINT [DF_Roles_RoleType] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__Roles__3214EC07F59812CC] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Administrator = 0,
 Recruiter = 1, Candidate = 2', @level0type = N'SCHEMA', @level0name = N'auth', @level1type = N'TABLE', @level1name = N'Roles', @level2type = N'COLUMN', @level2name = N'RoleType';

