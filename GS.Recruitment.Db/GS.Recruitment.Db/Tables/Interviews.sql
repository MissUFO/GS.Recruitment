CREATE TABLE [process].[Interviews] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [TaskId]          UNIQUEIDENTIFIER NOT NULL,
    [AssignmentId]    UNIQUEIDENTIFIER NULL,
    [ContactDetailId] UNIQUEIDENTIFIER NOT NULL,
    [RecruiterUserId] UNIQUEIDENTIFIER NOT NULL,
    [Title]           NVARCHAR (1024)  NOT NULL,
    [Description]     NVARCHAR (MAX)   NULL,
    [Stage]           TINYINT          CONSTRAINT [DF_Interviews_Stage] DEFAULT ((1)) NOT NULL,
    [Status]          TINYINT          CONSTRAINT [DF_Interviews_Status] DEFAULT ((0)) NOT NULL,
    [Comment]         NVARCHAR (MAX)   NULL,
    [CreatedOn]       DATETIME         CONSTRAINT [DF_Interviews_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]      DATETIME         CONSTRAINT [DF_Interviews_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NULL,
    [ModifiedBy]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Interviews] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Interviews_Assignments] FOREIGN KEY ([AssignmentId]) REFERENCES [process].[Assignments] ([Id]),
    CONSTRAINT [FK_Interviews_Details] FOREIGN KEY ([ContactDetailId]) REFERENCES [contact].[Details] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Interviews_Tasks] FOREIGN KEY ([TaskId]) REFERENCES [process].[Tasks] ([Id])
);

