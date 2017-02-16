CREATE TABLE [contact].[Connections] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [ParentId]        UNIQUEIDENTIFIER NULL,
    [ContactDetailId] UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]       DATETIME         CONSTRAINT [DF_Connections_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]      DATETIME         CONSTRAINT [DF_Connections_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NULL,
    [ModifiedBy]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Connections] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Connections_Details] FOREIGN KEY ([ContactDetailId]) REFERENCES [contact].[Details] ([Id]) ON DELETE CASCADE
);

