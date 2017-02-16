CREATE TABLE [auth].[UserRoles] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_UserRoles_Id] DEFAULT (newid()) NOT NULL,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [RoleId]    UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn] DATETIME         CONSTRAINT [DF_UserRoles_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy] UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY ([RoleId]) REFERENCES [auth].[Roles] ([Id]),
    CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY ([UserId]) REFERENCES [auth].[Users] ([Id])
);

