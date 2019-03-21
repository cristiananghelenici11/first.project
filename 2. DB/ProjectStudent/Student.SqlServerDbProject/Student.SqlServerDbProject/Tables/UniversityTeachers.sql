CREATE TABLE [dbo].[UniversityTeachers]
(
	[Id] BIGINT IDENTITY(1,1),
	[UniversityId] BIGINT NOT NULL,
	[TeacherId] BIGINT NOT NULL,
	CONSTRAINT UK_UniversityTeachers UNIQUE (UniversityId, TeacherId),
	CONSTRAINT PK_UniversityTeachers PRIMARY KEY (Id),
	CONSTRAINT FK_UPToUniversities FOREIGN KEY (UniversityId)
	REFERENCES Universities(Id),
	CONSTRAINT FK_UPToTeachers FOREIGN KEY (TeacherId)
	REFERENCES Teachers(Id)
)
