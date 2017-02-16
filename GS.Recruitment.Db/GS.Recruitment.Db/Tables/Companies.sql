CREATE TABLE [enum].[Companies] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [IndustryId] UNIQUEIDENTIFIER NOT NULL,
    [Name]       NVARCHAR (255)   NOT NULL,
    [CreatedOn]  DATETIME         CONSTRAINT [DF_Companies_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn] DATETIME         CONSTRAINT [DF_Companies_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]  UNIQUEIDENTIFIER NULL,
    [ModifiedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Companies_Industries] FOREIGN KEY ([IndustryId]) REFERENCES [enum].[Industries] ([Id]) ON DELETE CASCADE
);

