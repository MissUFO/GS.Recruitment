CREATE TABLE [contact].[UserDetails] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [UserId]          UNIQUEIDENTIFIER NOT NULL,
    [ContactDetailId] UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]       DATETIME         CONSTRAINT [DF_UserDetails_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]      DATETIME         CONSTRAINT [DF_UserDetails_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NULL,
    [ModifiedBy]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserDetails_Details] FOREIGN KEY ([ContactDetailId]) REFERENCES [contact].[Details] ([Id]),
    CONSTRAINT [FK_UserDetails_Users] FOREIGN KEY ([UserId]) REFERENCES [auth].[Users] ([Id])
);

