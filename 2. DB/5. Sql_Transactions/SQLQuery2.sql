BEGIN TRANSACTION
UPDATE packages
SET monthly_payment = 100
WHERE pack_id = 1;

WAITFOR DELAY '00:00:10'

UPDATE sectors
SET sector_name = 'updated'
WHERE sector_id = 1;

ROLLBACK
