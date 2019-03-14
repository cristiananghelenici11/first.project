USE ACDB;

-- Inner Join

--1. a 
SELECT customers.First_Name, customers.Last_Name, packages.pack_id, packages.speed
FROM customers
INNER JOIN packages ON customers.pack_id = packages.pack_id; 

--1. b
SELECT c.First_Name, c.Last_Name, p.pack_id, p.speed
FROM customers AS c
INNER JOIN packages AS p
ON c.pack_id = p.pack_id
WHERE c.pack_id = 27 OR c.pack_id = 22
ORDER BY c.Last_Name

--2. a
SELECT p.pack_id, p.speed, p.monthly_payment, s.sector_id
FROM packages AS p
INNER JOIN sectors AS s
ON p.sector_id = s.sector_id 

--2.b
SELECT c.First_Name + ' ' + c.Last_Name AS Name, p.pack_id, p.speed, s.sector_name
FROM customers AS c
INNER JOIN packages AS p ON c.pack_id = p.pack_id
INNER JOIN sectors AS s ON p.sector_id = s.sector_id

--2. c
SELECT c.Last_Name + ' ' + c.Last_Name AS Name, p.pack_id, p.speed, p.monthly_payment, s.sector_name 
FROM customers AS c 
INNER JOIN packages AS p ON c.pack_id = p.pack_id
INNER JOIN sectors AS s ON p.sector_id = s.sector_id
WHERE s.sector_name = 'Business'

--3.
SELECT c.Last_Name, c.First_Name, c.Join_Date, c.pack_id, p.speed, s.sector_name
FROM customers AS c
INNER JOIN packages AS p ON c.pack_id = p.pack_id
INNER JOIN sectors AS s ON p.sector_id = s.sector_id
WHERE s.sector_name = 'Private' AND c.Join_Date = '2006'

--4.a
SELECT c.First_Name, c.Last_Name, p.speed, p.monthly_payment
FROM customers AS c
INNER JOIN packages AS p ON c.pack_id = p.pack_id

--4.b
SELECT c.First_Name, c.Last_Name, p.speed, p.monthly_payment
FROM customers AS c
LEFT JOIN packages AS p ON c.pack_id = p.pack_id

--4.c
SELECT c.First_Name, c.Last_Name, p.speed, p.monthly_payment
FROM customers AS c
RIGHT JOIN packages AS p ON c.pack_id = p.pack_id

--4.d
SELECT c.First_Name, c.Last_Name, p.speed, p.monthly_payment
FROM customers AS c
FULL JOIN packages AS p ON c.pack_id = p.pack_id

--Projection Queries 
SELECT DISTINCT(First_Name) AS [Name]
FROM ACDB.dbo.customers
GROUP BY First_Name
HAVING Count(First_Name) > 0
ORDER BY Name DESC

--Use is Null logic, use like, combine predicates
SELECT Last_Name, COUNT(Join_Date)
FROM ACDB.dbo.customers
WHERE Join_Date > '2007'
GROUP BY Last_Name
HAVING COUNT(Last_Name) > 0
ORDER BY Last_Name  DESC

SELECT First_Name 
FROM customers
WHERE First_Name LIKE '%a%' AND First_Name IS NOT NULL

SELECT State, MIN(monthly_discount) AS MinMonthly_discount
FROM customers
WHERE monthly_discount > 10
GROUP BY State

SELECT COUNT(DISTINCT speed) AS CountDistinctSpeed
FROM packages