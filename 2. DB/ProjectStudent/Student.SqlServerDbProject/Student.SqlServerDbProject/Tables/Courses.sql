CREATE TABLE [dbo].[Courses]
(
 [Id] BIGINT IDENTITY(1,1),
    [Name] NVARCHAR(64) NOT NULL,
    [Description] NVARCHAR(256) NOT NULL,
    [Credits] INT NOT NULL,
    [YearOfStudy] INT NOT NULL,
	[FacultyId] BIGINT NOT NULL,
	CONSTRAINT CHK_Credits CHECK (Credits>0),
	CONSTRAINT CHK_YearOfStudy CHECK (YearOfStudy>0),
	CONSTRAINT PK_CourseId PRIMARY KEY (Id),
	CONSTRAINT FK_CourseToFaculty FOREIGN KEY ([FacultyId])
	REFERENCES Faculties(Id)     
)
