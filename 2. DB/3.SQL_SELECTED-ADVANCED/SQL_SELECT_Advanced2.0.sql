--L3
-- P1 Basic Usage
USE ACDB;
--1.1
SELECT TOP(1) Last_Name
FROM customers
ORDER BY Last_Name DESC

SELECT MAX(Last_Name) AS LowestLastName
FROM customers

--1.2
SELECT AVG(monthly_payment) AS AvgMonthlyPayment
FROM packages

--1.3
SELECT TOP(1) Last_Name
FROM customers
WHERE Last_Name IS NOT NULL
ORDER BY Last_Name ASC


SELECT * FROM customers

SELECT MIN(Last_Name) AS Last_Name1
FROM customers

--1.4
SELECT COUNT(pack_id) AS CountOfPack
FROM packages

--1.5
SELECT COUNT(customer_id) AS CountOfCustomers
FROM customers

--1.6
SELECT COUNT (DISTINCT [State]) AS CountDistinctState
FROM customers

--1.7
SELECT COUNT(DISTINCT speed) AS CountDistinctSpeed
FROM packages

--1.8
SELECT COUNT(*) AS CountNullFax
FROM customers

WHERE fax IS NOT NULL

--1.9
SELECT COUNT(*) AS CountNotNullFax
FROM customers
WHERE fax IS NULL

--1.10
SELECT MAX(monthly_discount) AS HighestMonthly_Discount,
		MIN(monthly_discount) AS LowestMonthly_Discount,
		AVG(monthly_discount) AS AverageMonthly_Discount
FROM customers
----------------------------------------------------------
--GROUP BY and HAVING clauses

--2.1
SELECT [State], COUNT(Customer_Id) AS NumberOfCustomers
FROM customers
GROUP BY [State]

--2.2
SELECT speed, AVG(monthly_payment)
FROM packages
GROUP BY speed

--2.3
SELECT [State], COUNT(DISTINCT City) AS NumberOfCity
FROM customers
GROUP BY [State] 

--2.4
SELECT sector_id, MAX(monthly_payment) AS HighestMonthly_payment
FROM packages
GROUP BY sector_id
 --
SELECT s.sector_id, MAX(monthly_payment) AS HighestMonthly_payment
FROM packages AS p
INNER JOIN sectors AS s ON p.sector_id = s.sector_id
GROUP BY s.sector_id

--2.5---

--2.6
SELECT p.pack_id, AVG(c.monthly_discount) AS AvgMonthly_discount
FROM packages AS p
LEFT JOIN customers AS c ON p.pack_id=c.pack_id
GROUP BY p.pack_id


--2.7
SELECT p.pack_id, AVG(c.monthly_discount) AS AvgMonthly_discount
FROM customers AS c
RIGHT JOIN packages AS p ON c.pack_id=p.pack_id
WHERE p.pack_id = 22 OR p.pack_id = 13
GROUP BY p.pack_id 
--HAVING p.pack_id = 22 OR p.pack_id = 13

--2.8
SELECT speed, MAX(monthly_payment) AS MaxMontly_payment, 
		MIN(monthly_payment) AS MinMontly_payment,
		AVG(monthly_payment) AS AvgMontly_payment
FROM packages
GROUP BY speed

--2.9
SELECT COUNT(c.Customer_Id) AS NumberOfCustomers
FROM customers AS c
RIGHT JOIN packages AS p ON c.pack_id=p.pack_id
GROUP BY p.pack_id

--2.10
SELECT p.pack_id, COUNT(c.Customer_Id) AS NumberOfCustomers
FROM customers AS c 
RIGHT JOIN packages AS p ON C.pack_id = p.pack_id
GROUP BY p.pack_id

--2.11
SELECT p.pack_id, COUNT(c.Customer_Id) AS NumberOfCustomers
FROM customers AS c 
RIGHT JOIN packages AS p ON C.pack_id = p.pack_id
WHERE c.monthly_discount > 20
GROUP BY p.pack_id

--2.12
SELECT p.pack_id, COUNT(c.Customer_Id) AS CountCustomer
FROM customers AS c
RIGHT JOIN packages AS p ON c.pack_id=p.pack_id
GROUP BY p.pack_id
HAVING COUNT(c.Customer_Id) > 100

--2.13
SELECT [State], City, COUNT(Customer_Id) AS CountCustomer
FROM customers
GROUP BY [State], City

--2.14----

--2.15
SELECT City, AVG(monthly_discount) AS AvgMonthly_discount
FROM customers
GROUP BY City

--2.16
SELECT City, AVG(monthly_discount) AS AvgMonthly_discount
FROM customers
WHERE monthly_discount > 20
GROUP BY City

--2.17---

--2.18
SELECT [State], MIN(monthly_discount) AS MinMonthly_discount
FROM customers
GROUP BY [State]

--2.19
SELECT [State], MIN(monthly_discount) AS MinMonthly_discount
FROM customers
WHERE monthly_discount > 10
GROUP BY [State]

--2.20
SELECT speed, COUNT(pack_id) AS CountPack_id
FROM packages
GROUP BY speed
HAVING COUNT(pack_id) > 8
-------------------------

SELECT COUNT(*) AS COUNT FROM customers 

-- INSERT SELECT
SELECT customers.Customer_Id FROM customers WHERE Customer_Id>1500

SET IDENTITY_INSERT customers ON
INSERT INTO customers(Customer_Id, main_phone_num)
	SELECT TOP(2) Customer_Id+1550, main_phone_num
	FROM customers
SET IDENTITY_INSERT customers OFF

SELECT customers.Customer_Id FROM customers WHERE Customer_Id>1500

-- SELECT INTO
IF OBJECT_ID('MyCustomers', 'U') IS NOT NULL
	DROP TABLE MyCustomers;

SELECT TOP(10)customers.City, customers.Last_Name
INTO MyCustomers
FROM customers

SELECT * FROM MyCustomers
TRUNCATE TABLE MyCustomers

DELETE M
FROM MyCustomers AS M
INNER JOIN Customers AS C ON M.City = C.City
WHERE C.City = 'New York'


--update join
UPDATE customers
	SET customers.monthly_discount -= 0.05
	FROM customers AS c
	INNER JOIN MyCustomers AS m ON c.City=m.City

--MERGE

CREATE TABLE MyCustomersTest
(
	[Id] BIGINT,
	[First_Name] NVARCHAR(100)
);

INSERT INTO MyCustomersTest(Id, First_Name)
	VALUES
		(1, 'Cristian'),
		(2, 'Charles'),
		(3, 'Alvin'),
		(4, 'AlvinA'),
		(30000, 'Alvin');

SELECT * FROM MyCustomersTest

DELETE MyCustomersTest;


MERGE INTO MyCustomersTest AS m
USING customers AS c
ON c.Customer_Id = m.ID

WHEN MATCHED THEN 
	UPDATE 
		SET m.ID = c.Customer_Id,
			m.First_Name = 'MATCHED'

WHEN NOT MATCHED THEN 
	INSERT (Id, First_Name)
		VALUES (c.Customer_Id, c.First_Name)

WHEN NOT MATCHED BY SOURCE THEN
	UPDATE 
		SET m.First_Name = 'default';

SELECT * FROM MyCustomersTest
WHERE First_Name = 'default'

---------------
--output
DELETE MyCustomersTest
OUTPUT deleted.Id, deleted.First_Name
WHERE  Id = 1;

INSERT INTO MyCustomersTest (Id, First_Name)
OUTPUT inserted.Id, inserted.First_Name
	VALUES
		(100, 'Cristian')

UPDATE MyCustomersTest
	SET First_Name = '222'
OUTPUT deleted.Id, deleted.First_Name, inserted.Id, inserted.First_Name
WHERE Id = 100
