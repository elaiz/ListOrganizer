CREATE TABLE [dbo].[Item] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (64)  NOT NULL,
    [Description] VARCHAR (256) NULL,
    [CategoryId]  INT           NULL,
    [Own]         BIT           NOT NULL,
    [Priority]    INT           NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC)
);

