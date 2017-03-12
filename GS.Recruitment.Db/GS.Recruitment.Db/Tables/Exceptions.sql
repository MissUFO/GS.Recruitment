CREATE TABLE [log].[Exceptions] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [Number]        INT              IDENTITY (1, 1) NOT NULL,
    [Message]       NVARCHAR (1024)  NOT NULL,
    [Exception]     NVARCHAR (MAX)   NULL,
    [Location]      NVARCHAR (1024)  NULL,
    [ExceptionType] TINYINT          CONSTRAINT [DF_Exceptions_Type] DEFAULT ((0)) NOT NULL,
    [ExceptionOn]   DATETIME         CONSTRAINT [DF_Exceptions_ExceptionOn] DEFAULT (getdate()) NOT NULL,
    [UserId]        UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Exceptions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

