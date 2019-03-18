--Try Out transactions in three modes
USE ACDB;
--AUTOCOMITED
SET IDENTITY_INSERT sectors ON;
INSERT INTO sectors(sector_id, sector_name) 
	VALUES 
		(120, 'action')
SELECT * FROM sectors WHERE sector_id=120
DELETE FROM sectors WHERE sector_id=120
SET IDENTITY_INSERT sectors OFF
------------------------------------------
--IMPLICIT TRANSACTION
SET IDENTITY_INSERT sectors ON;
SET IMPLICIT_TRANSACTIONS ON
INSERT INTO sectors(sector_id, sector_name) 
	VALUES 
		(220, 'action')

SET IDENTITY_INSERT sectors OFF

SELECT * FROM sectors WHERE sector_id = 220
DELETE FROM sectors WHERE sector_id = 220
-----------------------------------------
--- Explicit Transaction

BEGIN TRANSACTION CustomInsert
SET IDENTITY_INSERT sectors ON;
		INSERT INTO sectors(sector_id, sector_name) 
			VALUES (54, 'value 1'),
				   (55, 'value 2'),
				   (56, 'value 3');

COMMIT TRANSACTION CustomInsert
SET IDENTITY_INSERT [sectors] OFF;

SELECT * FROM sectors WHERE sector_id > 53 AND sector_id < 57
DELETE FROM sectors WHERE sector_id>53 AND sector_id < 57

---------------------------------------
--NESTED TRANSACTION
BEGIN TRANSACTION CustomInsert
SET IDENTITY_INSERT sectors ON;

	INSERT INTO sectors(sector_id, sector_name) 
		VALUES (54, 'value 1'),
			   (55, 'value 2'),
			   (56, 'value 3');
	BEGIN TRANSACTION CustomInsertNested
		INSERT INTO sectors(sector_id, sector_name) 
			VALUES 
				(57, 'value 1'),
				(58, 'value 2')

	COMMIT TRANSACTION CustomInsertNested
COMMIT TRANSACTION CustomInsert

SET IDENTITY_INSERT [sectors] OFF;

SELECT * FROM sectors WHERE sector_id > 53 AND sector_id < 59
DELETE FROM sectors WHERE sector_id>53 AND sector_id < 59
-------------------------------------------------------------

--Block another transaction and view the locks.

BEGIN TRANSACTION
UPDATE sectors
SET sector_name = 'updated'
WHERE sector_id = 1;
WAITFOR DELAY '00:00:10'


UPDATE packages
SET monthly_payment = 100
WHERE pack_id = 1;

ROLLBACK

------------------------------------------------------------
--DIRTY READ

BEGIN TRANSACTION

UPDATE sectors
SET sector_name = 'DIRTY READ'
WHERE sector_id = 10000

WAITFOR DELAY '00:00:10'
ROLLBACK
SELECT * FROM sectors

--NON-REPEATABLE READ

SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
SELECT * FROM sectors
WAITFOR DELAY '00:00:10'
SELECT * FROM sectors
COMMIT

---PHANTOM READS

SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRAN
SELECT * FROM sectors
WAITFOR DELAY '00:00:10'
SELECT * FROM sectors
COMMIT