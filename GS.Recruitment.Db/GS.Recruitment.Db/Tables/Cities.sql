CREATE TABLE [enum].[Cities] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Name]       NVARCHAR (255)   NOT NULL,
    [CountryId]  UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]  DATETIME         CONSTRAINT [DF_Cities_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn] DATETIME         CONSTRAINT [DF_Cities_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]  UNIQUEIDENTIFIER NULL,
    [ModifiedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK__Cities__3214EC07184E0381] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cities_Countries] FOREIGN KEY ([CountryId]) REFERENCES [enum].[Countries] ([Id]) ON DELETE CASCADE
);

