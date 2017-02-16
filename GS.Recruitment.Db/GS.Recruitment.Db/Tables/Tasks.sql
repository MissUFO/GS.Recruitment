CREATE TABLE [process].[Tasks] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Title]       NVARCHAR (1024)  NOT NULL,
    [Description] NVARCHAR (MAX)   NULL,
    [UserFromId]  UNIQUEIDENTIFIER NOT NULL,
    [UserToId]    UNIQUEIDENTIFIER NOT NULL,
    [TaskStatus]  TINYINT          CONSTRAINT [DF_Tasks_TaskStatus] DEFAULT ((0)) NOT NULL,
    [CreatedOn]   DATETIME         CONSTRAINT [DF_Tasks_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]  DATETIME         CONSTRAINT [DF_Tasks_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NULL,
    [ModifiedBy]  UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK__Tasks__3214EC0768FCA0D1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tasks_Users1] FOREIGN KEY ([UserToId]) REFERENCES [auth].[Users] ([Id]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'New =0, InProg = 1, Completed=2, Closed=3', @level0type = N'SCHEMA', @level0name = N'process', @level1type = N'TABLE', @level1name = N'Tasks', @level2type = N'COLUMN', @level2name = N'TaskStatus';

