CREATE TABLE [process].[TaskAssignments] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [TaskId]       UNIQUEIDENTIFIER NOT NULL,
    [AssignmentId] UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]    DATETIME         CONSTRAINT [DF_TaskAssignments_Created] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]    UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_TaskAssignments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TaskAssignments_Assignments] FOREIGN KEY ([AssignmentId]) REFERENCES [process].[Assignments] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TaskAssignments_Tasks] FOREIGN KEY ([TaskId]) REFERENCES [process].[Tasks] ([Id]) ON DELETE CASCADE
);

