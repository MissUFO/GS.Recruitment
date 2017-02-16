CREATE TABLE [msg].[Notifications] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Subject]          NVARCHAR (255)   NOT NULL,
    [Message]          NVARCHAR (MAX)   NULL,
    [NotificationType] INT              CONSTRAINT [DF_Table_1_MessageType] DEFAULT ((0)) NOT NULL,
    [UserId]           UNIQUEIDENTIFIER NOT NULL,
    [EntityId]         UNIQUEIDENTIFIER NULL,
    [EntityType]       INT              CONSTRAINT [DF_Notifications_EntityType] DEFAULT ((0)) NOT NULL,
    [CreatedOn]        DATETIME         CONSTRAINT [DF_Notifications_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [IsReceived]       BIT              CONSTRAINT [DF_Notifications_IsReceived] DEFAULT ((0)) NULL,
    [ReceivedOn]       DATETIME         NULL,
    CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED ([Id] ASC)
);

