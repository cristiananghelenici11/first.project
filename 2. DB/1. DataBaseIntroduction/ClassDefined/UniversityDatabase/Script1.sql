CREATE TABLE [dbo].[Customers]
(
    [Id]                BIGINT        NOT NULL,
    [Name]              NVARCHAR (50) NOT NULL,
    [DefaultPostalCode] BIGINT        NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id])
);
