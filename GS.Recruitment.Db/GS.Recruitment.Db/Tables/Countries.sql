CREATE TABLE [enum].[Countries] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Name]       NVARCHAR (255)   NOT NULL,
    [CreatedOn]  DATETIME         CONSTRAINT [DF_Countries_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn] DATETIME         CONSTRAINT [DF_Countries_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]  UNIQUEIDENTIFIER NULL,
    [ModifiedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([Id] ASC)
);

