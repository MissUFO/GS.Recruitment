CREATE TABLE [contact].[Educations] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [ContactDetailId] UNIQUEIDENTIFIER NOT NULL,
    [Name]            NVARCHAR (255)   NOT NULL,
    [Description]     NVARCHAR (MAX)   NULL,
    [CityId]          UNIQUEIDENTIFIER NULL,
    [DateFrom]        DATETIME         NOT NULL,
    [DateTo]          DATETIME         NULL,
    [IsCurrent]       BIT              CONSTRAINT [DF_Education_IsCurrent] DEFAULT ((0)) NOT NULL,
    [IsGraduated]     BIT              CONSTRAINT [DF_Education_IsGraduated] DEFAULT ((0)) NOT NULL,
    [GraduatedAs]     INT              CONSTRAINT [DF_Education_GraduatedAs] DEFAULT ((0)) NOT NULL,
    [CreatedOn]       DATETIME         CONSTRAINT [DF_Education_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]      DATETIME         CONSTRAINT [DF_Education_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NULL,
    [ModifiedBy]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Education_Details] FOREIGN KEY ([ContactDetailId]) REFERENCES [contact].[Details] ([Id]) ON DELETE CASCADE
);

