CREATE TABLE [contact].[Skills] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [ContactDetailId] UNIQUEIDENTIFIER NOT NULL,
    [SkillId]         UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]       DATETIME         CONSTRAINT [DF_Skills_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]      DATETIME         CONSTRAINT [DF_Skills_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NULL,
    [ModifiedBy]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Skills_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Skills_Details] FOREIGN KEY ([ContactDetailId]) REFERENCES [contact].[Details] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Skills_Skills] FOREIGN KEY ([SkillId]) REFERENCES [enum].[Skills] ([Id])
);

