CREATE TABLE [contact].[JobPreferences] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
    [ContactDetailId]      UNIQUEIDENTIFIER NOT NULL,
    [SalaryFrom]           MONEY            NULL,
    [SalaryTo]             MONEY            NULL,
    [JobTitleId]           UNIQUEIDENTIFIER NULL,
    [CityId]               UNIQUEIDENTIFIER NULL,
    [CountryId]            UNIQUEIDENTIFIER NULL,
    [IsReadyForRelocation] BIT              CONSTRAINT [DF_JobPreferences_IsReadyForRelocation] DEFAULT ((0)) NOT NULL,
    [Description]          NVARCHAR (MAX)   NULL,
    [LastContactDate]      DATETIME         NULL,
    [LastContactedBy]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_JobPreferences] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_JobPreferences_Cities] FOREIGN KEY ([CityId]) REFERENCES [enum].[Cities] ([Id]),
    CONSTRAINT [FK_JobPreferences_Countries] FOREIGN KEY ([CountryId]) REFERENCES [enum].[Countries] ([Id]),
    CONSTRAINT [FK_JobPreferences_Details] FOREIGN KEY ([ContactDetailId]) REFERENCES [contact].[Details] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_JobPreferences_JobTitles] FOREIGN KEY ([JobTitleId]) REFERENCES [enum].[JobTitles] ([Id])
);

