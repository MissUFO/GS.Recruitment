CREATE TABLE [contact].[SocialNetworks] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [ContactDetailId]   UNIQUEIDENTIFIER NOT NULL,
    [UserName]          NVARCHAR (255)   NULL,
    [ProfileUrl]        NVARCHAR (2048)  NULL,
    [SocialNetworkType] INT              CONSTRAINT [DF_SocialNetworks_SocialNetworkType] DEFAULT ((0)) NOT NULL,
    [CreatedOn]         DATETIME         CONSTRAINT [DF_SocialNetworks_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]        DATETIME         CONSTRAINT [DF_SocialNetworks_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]         UNIQUEIDENTIFIER NULL,
    [ModifiedBy]        UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_SocialNetworks] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SocialNetworks_Details] FOREIGN KEY ([ContactDetailId]) REFERENCES [contact].[Details] ([Id]) ON DELETE CASCADE
);

