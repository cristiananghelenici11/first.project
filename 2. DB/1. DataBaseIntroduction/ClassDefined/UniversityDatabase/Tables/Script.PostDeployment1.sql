/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
CREATE DATABASE Student;

USE Student;

CREATE TABLE Universities
(
    [Id] BIGINT IDENTITY(1,1),
    [Name] NVARCHAR(64) NOT NULL,
    [Address] NVARCHAR(128) NOT NULL,
    [Description] NVARCHAR(256) NOT NULL,
    [Contact] VARCHAR(64) NOT NULL,
    [Age] INT NOT NULL,
    CONSTRAINT PK_University PRIMARY KEY (Id),
    CONSTRAINT CHK_Age CHECK (Age>0)
);

CREATE TABLE Faculties
(
    [Id] BIGINT IDENTITY(1,1),
    [Name] NVARCHAR(64) NOT NULL,
    [Address] NVARCHAR(128) NOT NULL,
    [Description] NVARCHAR(256) NOT NULL,
    [UniverstityId] BIGINT NOT NULL,
    CONSTRAINT PK_Faculty PRIMARY KEY (Id),
    CONSTRAINT FK_FacultyToUniversity FOREIGN KEY (UniverstityId)
    REFERENCES Universities(Id)
);

CREATE TABLE Courses
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
);

CREATE TABLE Teachers
(
	[Id] BIGINT IDENTITY(1,1),
	[Idnp] BIGINT NOT NULL,
	[FirstName] NVARCHAR(64) NOT NULL,
	[LastName] NVARCHAR(64) NOT NULL,
	[Phone] VARCHAR(64) NOT NULL,
	[Email] NVARCHAR(64) NOT NULL,
	CONSTRAINT PK_Teachers PRIMARY KEY (Id),
	CONSTRAINT UK_Person UNIQUE (Idnp) 
);

CREATE TABLE CourseTeachers
(
	[Id] BIGINT IDENTITY(1,1),
	[TeacherId] BIGINT,
	[CourseId] BIGINT,
	CONSTRAINT PK_CourseTeachers PRIMARY KEY (Id),
	CONSTRAINT FK_CPToTeachers FOREIGN KEY (TeacherId)
	REFERENCES Teachers(Id),
	CONSTRAINT FK_CPToCourses FOREIGN KEY (CourseId)
	REFERENCES Courses(Id)
);

CREATE TABLE UniversityTeachers
(
	[Id] BIGINT IDENTITY(1,1),
	[UniversityId] BIGINT NOT NULL,
	[TeacherId] BIGINT NOT NULL,
	CONSTRAINT PK_UniversityTeachers PRIMARY KEY (Id),
	CONSTRAINT FK_UPToUniversities FOREIGN KEY (UniversityId)
	REFERENCES Universities(Id),
	CONSTRAINT FK_UPToTeachers FOREIGN KEY (TeacherId)
	REFERENCES Teachers(Id)
);

CREATE TABLE Users
(
	[Id] BIGINT IDENTITY(1,1),
	[UserName] NVARCHAR(64),
	[Password] NVARCHAR(64),
	[FirstName] NVARCHAR(64),
	[LastName] NVARCHAR(64),
	[Idnp] BIGINT NOT NULL,
	[Phone] VARCHAR(64) NOT NULL,
	[Email] NVARCHAR(64) NOT NULL,
	CONSTRAINT UK_UserIdnp UNIQUE (IDNP),
	CONSTRAINT UK_UserPassword UNIQUE ([Password]),
	CONSTRAINT PK_Users PRIMARY KEY (Id)
);

CREATE TABLE Marks
(
	[Id] BIGINT IDENTITY(1,1),
	[TypeMark] NVARCHAR(64) NOT NULL,
	[Value] FLOAT(2),
	[TeacherId] BIGINT,
	[CourseId] BIGINT,
	[UserId] BIGINT,
	CONSTRAINT PK_Marks PRIMARY KEY (Id),
	CONSTRAINT CHK_Value CHECK ([Value]>0 AND [Value]<10),
	CONSTRAINT CHK_Mark CHECK(TeacherId IS NOT NULL OR CourseId IS NOT NULL),
	CONSTRAINT UC_Marks UNIQUE (TeacherId,CourseId,UserId),

	CONSTRAINT FK_MarkToUser FOREIGN KEY (UserId)
	REFERENCES Users(Id),
	CONSTRAINT FK_MarkToTeachers FOREIGN KEY (TeacherId)
	REFERENCES Teachers(Id),
	CONSTRAINT FK_MarkToCourse FOREIGN KEY (CourseId)
	REFERENCES Courses(Id)

);

CREATE TABLE Comments
(
	[Id] BIGINT IDENTITY(1,1),
	[Subject] NVARCHAR(64) NULL,
	[Message] NVARCHAR(MAX) NOT NULL,
	[CourseId] BIGINT,
	[TeacherId] BIGINT,
	CONSTRAINT PK_Comment PRIMARY KEY (Id),
	
	CONSTRAINT CHK_Comment CHECK(TeacherId IS NOT NULL OR CourseId IS NOT NULL),
	CONSTRAINT FK_CommentToTeachers FOREIGN KEY (TeacherId)
	REFERENCES Teachers(Id),
	CONSTRAINT FK_CommentToCourses FOREIGN KEY (CourseId)
	REFERENCES Courses(Id),
	CONSTRAINT FK_CommentToUsers FOREIGN KEY (Id)
	REFERENCES Users(Id)
);

-----------------------------------------------------------

INSERT INTO Universities (Name, Address, Description, Contact, Age)
	VALUES
		('UTM', 'Chisinau', 'Universitatea Tehnica a Moldovei', 068559687, 55),
		('USM', 'Chisinau', 'Universitatea de Stat a Moldovei', 068559687, 55);

INSERT INTO Faculties (Name, Address, Description, UniverstityId)
	Values
		('FCIM', 'Studentilor 7/1', 'Facultatea de Calculatoare Informatica', 1),
		('FEIE', 'str. 31 August 1989', 'Facultatea Energetică și Inginerie Electrică', 1),
		('FET', ' bd. Ştefan cel Mare, 168,', 'Facultatea Electronică și Telecomunicații', 1),
		('FIEB', 'bd. Dacia, 41', 'Facultatea Inginerie Economică şi Business', 1);

INSERT INTO Courses (Name, Description, Credits, YearOfStudy, FacultyId)
	VALUES
		('OOP', 'Programarea Orientata pe Obiecte', 30, 2, 1),
		('BDC', 'Baze de Date', 30, 3, 1),
		('PP', 'Programarea Procedurala', 25, 3, 1),
		('AC', 'Ajhds Cerojf', 20, 1, 1);

INSERT INTO Teachers (Idnp, FirstName, LastName, Phone, Email)
	VALUES
		(12345, 'Anghelenici', 'Cristian', 068559687, 'cristian.anghelenici@gmail.com'),
		(12346, 'Moraru', 'Victor', 068447682, 'victor.moraru@gmail.com'),
		(12347, 'Melnic', 'Adrian', 068445825, 'adrian.moraru@gmail.com');

INSERT INTO Users (UserName, Password, FirstName, LastName, Idnp, Phone, Email)
	VALUES
		('crist1', 'Christy32', 'Profir', 'Cristian', 12341, 068559643, 'cristian.profir@gmail.com'),
		('ion12', 'Ioncu391', 'Trofim', 'Ion', 12342, 078556327, 'ion.trofim@gmai.com'),
		('andrei32', 'Andrei78', 'Ionescu', 'Andrei', 12343, 061996739, 'andrei.ionescu@gmail.com');

INSERT INTO Marks (TypeMark, Value, TeacherId, CourseId, UserId)
	VALUES
		('1', 9, 1, 1, 1),
		('2', 8, 2, 2, 2),
		('3', 9, 3, 3, 3),
		('4', 7, 1, 2, 3);

INSERT INTO Comments (Subject, Message, CourseId, TeacherId)
	VALUES
		('s1', 'Message1', 1, 1),
		('s2', 'Message2', 2, 2),
		('s3', 'Message3', 3, 3);

INSERT INTO UniversityTeachers (UniversityId ,TeacherId)
	VALUES
		(1, 1),
		(1, 2),
		(1, 3);

INSERT INTO CourseTeachers (CourseId, TeacherId)
	VALUES
		(1, 1),
		(2, 2),
		(3, 3),
		(1, 2);


SELECT T.FirstName, T.LastName, AVG(M.Value) AS AvgMarks, C.Message
FROM Teachers AS T
INNER JOIN Marks AS M ON T.Id=M.TeacherId
INNER JOIN Comments AS C ON T.Id=C.Id
WHERE M.Value > 0
GROUP BY FirstName, LastName, Message
