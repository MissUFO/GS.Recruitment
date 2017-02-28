CREATE TABLE [process].[Assignments] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Number]           BIGINT           IDENTITY (1, 1) NOT NULL,
    [Title]            NVARCHAR (1024)  NOT NULL,
    [Description]      NVARCHAR (MAX)   NULL,
    [StartDate]        DATETIME         CONSTRAINT [DF_Assignments_StartDate] DEFAULT (getdate()) NULL,
    [EndDate]          DATETIME         NULL,
    [UserFromId]       UNIQUEIDENTIFIER NOT NULL,
    [UserToId]         UNIQUEIDENTIFIER NOT NULL,
    [AssignmentStatus] TINYINT          CONSTRAINT [DF_Assignments_AssignmentStatus] DEFAULT ((0)) NOT NULL,
    [CreatedOn]        DATETIME         CONSTRAINT [DF_Assignments_Created] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]       DATETIME         CONSTRAINT [DF_Assignments_Modified] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]        UNIQUEIDENTIFIER NULL,
    [ModifiedBy]       UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED ([Id] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'New =0, InProg = 1, Completed=2, Closed=3', @level0type = N'SCHEMA', @level0name = N'process', @level1type = N'TABLE', @level1name = N'Assignments', @level2type = N'COLUMN', @level2name = N'AssignmentStatus';

