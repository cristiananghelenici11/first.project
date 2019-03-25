--INSERT INTO Universities (Name, Address, Description, Contact, Age)
--	VALUES
--		('UTM', 'Chisinau', 'Universitatea Tehnica a Moldovei', 068559687, 55),
--		('USM', 'Chisinau', 'Universitatea de Stat a Moldovei', 068559687, 55);

--INSERT INTO Faculties (Name, Address, Description, UniverstityId)
--	Values
--		('FCIM', 'Studentilor 7/1', 'Facultatea de Calculatoare Informatica', 1),
--		('FEIE', 'str. 31 August 1989', 'Facultatea Energetica ?i Inginerie Electrica', 1),
--		('FET', ' bd. Stefan cel Mare, 168,', 'Facultatea Electronica ?i Telecomunica?ii', 1),
--		('FIEB', 'bd. Dacia, 41', 'Facultatea Inginerie Economica si Business', 1);

--INSERT INTO Courses (Name, Description, Credits, YearOfStudy, FacultyId)
--	VALUES
--		('OOP', 'Programarea Orientata pe Obiecte', 30, 2, 1),
--		('BDC', 'Baze de Date', 30, 3, 1),
--		('PP', 'Programarea Procedurala', 25, 3, 1),
--		('AC', 'Ajhds Cerojf', 20, 1, 1);

--INSERT INTO Teachers (Idnp, FirstName, LastName, Phone, Email)
--	VALUES
--		(12345, 'Anghelenici', 'Cristian', 068559687, 'cristian.anghelenici@gmail.com'),
--		(12346, 'Moraru', 'Victor', 068447682, 'victor.moraru@gmail.com'),
--		(12347, 'Melnic', 'Adrian', 068445825, 'adrian.moraru@gmail.com');

--INSERT INTO Users (UserName, Password, FirstName, LastName, Idnp, Phone, Email)
--	VALUES
--		('crist1', 'Christy32', 'Profir', 'Cristian', 12341, 068559643, 'cristian.profir@gmail.com'),
--		('ion12', 'Ioncu391', 'Trofim', 'Ion', 12342, 078556327, 'ion.trofim@gmai.com'),
--		('andrei32', 'Andrei78', 'Ionescu', 'Andrei', 12343, 061996739, 'andrei.ionescu@gmail.com');

--INSERT INTO Marks (TypeMark, Value, TeacherId, CourseId, UserId)
--	VALUES
--		('1', 9, 1, 1, 1),
--		('2', 8, 2, 2, 2),
--		('3', 9, 3, 3, 3),
--		('4', 7, 1, 2, 3);

--INSERT INTO Comments (Subject, Message, CourseId, TeacherId, UserId)
--	VALUES
--		('s1', 'Message1', 1, 1, 1),
--		('s2', 'Message2', 2, 2, 2),
--		('s3', 'Message3', 3, 3, 3);

--INSERT INTO UniversityTeachers (UniversityId ,TeacherId)
--	VALUES
--		(1, 1),
--		(1, 2),
--		(1, 3);

--INSERT INTO CourseTeachers (CourseId, TeacherId)
--	VALUES
--		(1, 1),
--		(2, 2),
--		(3, 3),
--		(1, 2);