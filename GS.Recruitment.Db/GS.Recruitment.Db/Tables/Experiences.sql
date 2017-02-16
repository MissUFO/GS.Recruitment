CREATE TABLE [contact].[Experiences] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [ContactDetailId] UNIQUEIDENTIFIER NOT NULL,
    [CompanyId]       UNIQUEIDENTIFIER NOT NULL,
    [JobTitleId]      UNIQUEIDENTIFIER NULL,
    [JobDescription]  NVARCHAR (MAX)   NULL,
    [CityId]          UNIQUEIDENTIFIER NULL,
    [DateFrom]        DATETIME         NOT NULL,
    [DateTo]          DATETIME         NULL,
    [IsCurrent]       BIT              CONSTRAINT [DF_Experiences_IsCurrent] DEFAULT ((0)) NOT NULL,
    [CreatedOn]       DATETIME         CONSTRAINT [DF_Experiences_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]      DATETIME         CONSTRAINT [DF_Experiences_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NULL,
    [ModifiedBy]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Experiences] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Experiences_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [enum].[Companies] ([Id]),
    CONSTRAINT [FK_Experiences_Details] FOREIGN KEY ([ContactDetailId]) REFERENCES [contact].[Details] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Experiences_JobTitles] FOREIGN KEY ([JobTitleId]) REFERENCES [enum].[JobTitles] ([Id])
);

