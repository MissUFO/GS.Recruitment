CREATE TABLE [contact].[Details] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [FirstName]  NVARCHAR (100)   NULL,
    [LastName]   NVARCHAR (100)   NOT NULL,
    [MiddleName] NVARCHAR (100)   NULL,
    [Address]    NVARCHAR (1024)  NULL,
    [PostCode]   NVARCHAR (50)    NULL,
    [CityId]     UNIQUEIDENTIFIER NULL,
    [CountryId]  UNIQUEIDENTIFIER NULL,
    [Birthday]   DATETIME         NULL,
    [CreatedOn]  DATETIME         CONSTRAINT [DF_Details_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn] DATETIME         CONSTRAINT [DF_Details_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]  UNIQUEIDENTIFIER NULL,
    [ModifiedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK__Personal__3214EC07B95775CC] PRIMARY KEY CLUSTERED ([Id] ASC)
);

