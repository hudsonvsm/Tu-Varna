﻿CREATE TABLE [dbo].[Class] (
    [Id]   UNIQUEIDENTIFIER CONSTRAINT [DF_Class_Id] DEFAULT (newid()) NOT NULL,
    [Name] NVARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED ([Id] ASC)
);

