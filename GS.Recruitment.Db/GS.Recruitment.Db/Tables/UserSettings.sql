CREATE TABLE [settings].[UserSettings] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [UserId]              UNIQUEIDENTIFIER NOT NULL,
    [SystemNotifications] BIT              CONSTRAINT [DF_UserSettings_EnableSystemNotifications] DEFAULT ((1)) NOT NULL,
    [EmailNotifications]  BIT              CONSTRAINT [DF_UserSettings_EnableEmailNotifications] DEFAULT ((1)) NOT NULL,
    [ModifiedOn]          DATETIME         CONSTRAINT [DF_UserSettings_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_UserSettings] PRIMARY KEY CLUSTERED ([Id] ASC)
);

