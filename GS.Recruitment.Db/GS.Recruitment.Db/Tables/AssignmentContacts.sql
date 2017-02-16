CREATE TABLE [process].[AssignmentContacts] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [AssignmentId]            UNIQUEIDENTIFIER NOT NULL,
    [ContactId]               UNIQUEIDENTIFIER NOT NULL,
    [AssignmentContactStatus] TINYINT          CONSTRAINT [DF_AssignmentContacts_Status] DEFAULT ((0)) NOT NULL,
    [Comment]                 NVARCHAR (MAX)   NULL,
    [CreatedOn]               DATETIME         CONSTRAINT [DF_AssignmentContacts_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]              DATETIME         NULL,
    [CreatedBy]               UNIQUEIDENTIFIER NULL,
    [ModifiedBy]              UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_AssignmentContacts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AssignmentContacts_Assignments] FOREIGN KEY ([AssignmentId]) REFERENCES [process].[Assignments] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AssignmentContacts_Details] FOREIGN KEY ([ContactId]) REFERENCES [contact].[Details] ([Id]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'New=0', @level0type = N'SCHEMA', @level0name = N'process', @level1type = N'TABLE', @level1name = N'AssignmentContacts', @level2type = N'COLUMN', @level2name = N'AssignmentContactStatus';

