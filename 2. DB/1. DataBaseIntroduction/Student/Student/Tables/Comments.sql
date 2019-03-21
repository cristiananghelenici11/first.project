CREATE TABLE [dbo].[Comments]
(
	[Id] BIGINT IDENTITY(1,1),
	[Subject] NVARCHAR(64) NULL,
	[Message] NVARCHAR(MAX) NOT NULL,
	[CourseId] BIGINT,
	[TeacherId] BIGINT,
	[UserId] BIGINT,
	CONSTRAINT PK_Comment PRIMARY KEY (Id),
	CONSTRAINT CHK_Comment CHECK(TeacherId IS NOT NULL OR CourseId IS NOT NULL),
	CONSTRAINT UC_Coments UNIQUE (TeacherId,CourseId,UserId),
	CONSTRAINT FK_CommentToTeachers FOREIGN KEY (TeacherId)
	REFERENCES Teachers(Id),
	CONSTRAINT FK_CommentToCourses FOREIGN KEY (CourseId)
	REFERENCES Courses(Id),
	CONSTRAINT FK_CommentToUsers FOREIGN KEY (UserId)
	REFERENCES Users(Id)
)
