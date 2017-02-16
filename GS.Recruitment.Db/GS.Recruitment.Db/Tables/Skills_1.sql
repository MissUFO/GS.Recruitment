CREATE TABLE [enum].[Skills] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Name]       NVARCHAR (255)   NOT NULL,
    [CreatedOn]  DATETIME         CONSTRAINT [DF_Skills_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn] DATETIME         CONSTRAINT [DF_Skills_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]  UNIQUEIDENTIFIER NULL,
    [ModifiedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED ([Id] ASC)
);

