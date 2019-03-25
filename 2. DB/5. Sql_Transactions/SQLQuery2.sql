
USE ACDB;
--Deadlocking
BEGIN TRANSACTION
UPDATE packages
SET monthly_payment = 100
WHERE pack_id = 1;

WAITFOR DELAY '00:00:10'

UPDATE sectors
SET sector_name = 'updated'
WHERE sector_id = 1;

COMMIT TRANSACTION
---------------------------

--Dirty
--------------------------
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION 
SELECT * FROM sectors
COMMIT TRANSACTION
-----------------------------
----NON-REPEATABLE READ

BEGIN TRANSACTION

UPDATE sectors
SET sector_name = 'change3'
WHERE sector_id = 1

COMMIT TRANSACTION

----
BEGIN TRAN

INSERT INTO sectors(sector_name) 
	VALUES 
		('qwerty')

COMMIT