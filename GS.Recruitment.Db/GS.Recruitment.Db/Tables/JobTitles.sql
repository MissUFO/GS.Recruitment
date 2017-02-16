CREATE TABLE [enum].[JobTitles] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Name]       NVARCHAR (255)   NOT NULL,
    [CreatedOn]  DATETIME         CONSTRAINT [DF_JobTitles_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn] DATETIME         CONSTRAINT [DF_JobTitles_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]  UNIQUEIDENTIFIER NULL,
    [ModifiedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_JobTitles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

