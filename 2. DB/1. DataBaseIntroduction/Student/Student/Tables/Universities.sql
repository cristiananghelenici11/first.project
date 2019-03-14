CREATE TABLE [dbo].[Universities]
(
	[Id] BIGINT IDENTITY(1,1),
    [Name] NVARCHAR(64) NOT NULL,
    [Address] NVARCHAR(128) NOT NULL,
    [Description] NVARCHAR(256) NOT NULL,
    [Contact] VARCHAR(64) NOT NULL,
    [Age] INT NOT NULL,
    CONSTRAINT PK_University PRIMARY KEY (Id),
    CONSTRAINT CHK_Age CHECK (Age>0)
)