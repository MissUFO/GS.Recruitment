CREATE TABLE [contact].[Attachments] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [ContactDetailId] UNIQUEIDENTIFIER NOT NULL,
    [FileName]        NVARCHAR (255)   NOT NULL,
    [FileContent]     VARBINARY (MAX)  NULL,
    [AttachmentType]  INT              CONSTRAINT [DF_Attachments_AttachmentType] DEFAULT ((0)) NULL,
    [CreatedOn]       DATETIME         CONSTRAINT [DF_Attachments_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]      DATETIME         CONSTRAINT [DF_Attachments_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NULL,
    [ModifiedBy]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Attachments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attachments_Details] FOREIGN KEY ([ContactDetailId]) REFERENCES [contact].[Details] ([Id]) ON DELETE CASCADE
);

