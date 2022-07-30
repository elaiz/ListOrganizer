CREATE TABLE [dbo].[Category] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (64)  NOT NULL,
    [Description] VARCHAR (256) NULL,
    CONSTRAINT [PK_ListCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

