CREATE TABLE [dbo].[Faculties]
(
	[Id] BIGINT IDENTITY(1,1),
    [Name] NVARCHAR(64) NOT NULL,
    [Address] NVARCHAR(128) NOT NULL,
    [Description] NVARCHAR(256) NOT NULL,
    [UniverstityId] BIGINT NOT NULL,
    CONSTRAINT PK_Faculty PRIMARY KEY (Id),
    CONSTRAINT FK_FacultyToUniversity FOREIGN KEY (UniverstityId)
    REFERENCES Universities(Id)
)
