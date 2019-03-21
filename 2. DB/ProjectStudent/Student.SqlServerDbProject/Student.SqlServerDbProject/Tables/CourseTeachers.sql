CREATE TABLE [dbo].[CourseTeachers]
(
	[Id] BIGINT IDENTITY(1,1),
	[TeacherId] BIGINT,
	[CourseId] BIGINT,
	CONSTRAINT PK_CourseTeachers PRIMARY KEY (Id),
	CONSTRAINT UK_CourseTeachers UNIQUE (TeacherId, CourseId),
	CONSTRAINT FK_CPToTeachers FOREIGN KEY (TeacherId)
	REFERENCES Teachers(Id),
	CONSTRAINT FK_CPToCourses FOREIGN KEY (CourseId)
	REFERENCES Courses(Id)
)
