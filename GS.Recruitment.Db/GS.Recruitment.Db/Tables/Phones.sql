CREATE TABLE [contact].[Phones] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [ContactDetailId] UNIQUEIDENTIFIER NOT NULL,
    [Phone]           NVARCHAR (50)    NOT NULL,
    [IsPreferred]     BIT              CONSTRAINT [DF_Phones_IsPreferred] DEFAULT ((1)) NOT NULL,
    [CreatedOn]       DATETIME         CONSTRAINT [DF_Phones_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]      DATETIME         CONSTRAINT [DF_Phones_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NULL,
    [ModifiedBy]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Phones_Details] FOREIGN KEY ([ContactDetailId]) REFERENCES [contact].[Details] ([Id]) ON DELETE CASCADE
);

