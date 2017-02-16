CREATE TABLE [contact].[Emails] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [ContactDetailId] UNIQUEIDENTIFIER NOT NULL,
    [Email]           NVARCHAR (255)   NOT NULL,
    [IsPreferred]     BIT              CONSTRAINT [DF_Emails_IsPreffered] DEFAULT ((1)) NOT NULL,
    [CreatedOn]       DATETIME         CONSTRAINT [DF_Emails_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]      DATETIME         CONSTRAINT [DF_Emails_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NULL,
    [ModifiedBy]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Emails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Emails_Details] FOREIGN KEY ([ContactDetailId]) REFERENCES [contact].[Details] ([Id]) ON DELETE CASCADE
);

