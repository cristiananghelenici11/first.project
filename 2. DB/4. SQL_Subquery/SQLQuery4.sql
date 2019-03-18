--1. Display the first name, last name, city and state for all customers who 
	--live in the same state as customer number 170.
SELECT First_Name, Last_Name, City, State
FROM customers
WHERE 
	State = (SELECT [State]
			 FROM customers 
			 WHERE Customer_Id = 170);

--2.2.	Display the package number, internet speed and sector number for all packages 
	--whose sector number equals to the sector number of package number 10.
SELECT p.pack_id, p.speed, p.sector_id
FROM packages AS p
WHERE 
	sector_id = (SELECT sector_id
				 FROM packages
				 WHERE pack_id = 10)

--3.	Display the first name, last name and join date for all customers 
	--who joined the company after customer number 540.
SELECT First_Name, Last_Name, Join_Date
FROM customers
WHERE Join_Date = (SELECT Join_Date
				   FROM customers
				   WHERE Customer_Id = 540
);

--4.	Display the first name, last name and join date for all customers 
	--who joined the company on the same month and on the same year as customer number 372 (Customers table).
SELECT First_Name, Last_Name, Join_Date
FROM customers
WHERE MONTH(Join_Date) = (SELECT MONTH(Join_Date) AS MonthDate
						  FROM customers 
						  WHERE Customer_Id = 372)  AND YEAR(Join_Date) = (SELECT YEAR(Join_Date)
																		   FROM customers
																		   WHERE Customer_Id = 372)

SELECT First_Name, Last_Name, Join_Date
FROM customers, (SELECT YEAR(Join_Date) AS JoinYear, MONTH(Join_Date) AS JoinMonth
				FROM customers
				WHERE Customer_Id = 372) AS DateTemp
WHERE YEAR(Join_Date) = DateTemp.JoinYear AND MONTH(Join_Date) = DateTemp.JoinMonth

---5.	Display the first name, last name, city, state and package number for all customers 
	--whose internet speed is “5Mbps” (Customers and Packages table).
SELECT [First_Name], [Last_Name], [City], [State], [pack_id]
FROM customers
WHERE customers.pack_id IN (SELECT pack_id
					        FROM packages
	                        WHERE speed = '5Mbps')

--6.	Display the package number, internet speed and strt_date (the date it became available) 
	--for all packages who became available on the same year as package number 7 (Packages table).
SELECT pack_id, speed, strt_date
FROM packages
WHERE YEAR(strt_date) = (SELECT YEAR(strt_date)
					     FROM packages
						 WHERE pack_id =7)

--7.	Display the first name, monthly discount, package number, main phone number and secondary phone number for all customers 
	--whose sector name is Business (Customers, Packages and Sectors tables).
SELECT First_Name, monthly_discount, pack_id, main_phone_num, secondary_phone_num
FROM customers
WHERE pack_id IN (SELECT p.pack_id
				  FROM packages AS P
				  INNER JOIN sectors AS s ON p.sector_id=s.sector_id
				  WHERE s.sector_name='Business');

SELECT First_Name, monthly_discount, pack_id, main_phone_num, secondary_phone_num
FROM customers
WHERE pack_id IN (SELECT pack_id
				  FROM packages
				  WHERE sector_id IN (SELECT sector_id
									  FROM sectors
									  WHERE sector_name = 'Business'))
--8.	Display the first name, monthly discount and package number for all customers whose monthly payment is 
	--greater than the average monthly payment (Customers and Packages patable).

SELECT First_Name, monthly_discount, pack_id
FROM customers
WHERE pack_id IN (SELECT pack_id
				  FROM packages
				  WHERE monthly_payment > (SELECT AVG(monthly_payment) 
									       FROM packages));

--9.	Display the first name, city, state, birthdate and monthly discount for all customers 
	--who was born on the same date as customer number 179, and whose monthly discount is greater than the monthly discount of customer number 107 (Customers table)
SELECT First_Name, City, State, Birth_Date, monthly_discount
FROM customers
WHERE Customer_Id IN ( SELECT Customer_Id
		FROM customers
		WHERE Customer_Id = 107 AND monthly_discount > (SELECT monthly_discount
														FROM customers
														WHERE Customer_Id = 107))
---
SELECT [First_Name], [City], [State], [Birth_Date], [monthly_discount]
FROM [customers]
WHERE [Birth_Date] = (	SELECT [Birth_Date] 
						FROM [customers] 
						WHERE [Customer_Id] = 179) AND [monthly_discount] = (	SELECT [monthly_discount] 
																				FROM [customers] 
																				WHERE [Customer_Id] = 107)
--10.	Display all the data from Packages table for packages whose internet speed equals to the internet speed of package number 30, and whose
	-- monthly payment is greater than the monthly payment of package number 7 (Packages table).
SELECT *
FROM packages
WHERE speed = ( SELECT speed
				FROM packages
				WHERE pack_id = 30) AND monthly_payment > (SELECT monthly_payment
														   FROM packages
														   WHERE pack_id = 7)
--ACID 
--11.	Display the package number, internet speed, and monthly payment for all packages whose monthly payment 
	--is greater than the maximum monthly payment of packages with internet speed equals to “5Mbps” (Packages table).
SELECT pack_id, speed, monthly_payment
FROM packages
WHERE monthly_payment > (SELECT MAX(monthly_payment) 
					     FROM packages
						 WHERE speed = '5Mbps')

--12	Display  the package number, internet speed and monthly payment for all packages whose monthly payment 
	--is greater than the minimum monthly payment of packages with internet speed equals to “5Mbps” (Packages table).
SELECT pack_id, speed, monthly_payment
FROM packages
WHERE monthly_payment > (SELECT MIN(monthly_payment)
						 FROM packages
						 WHERE speed = '5Mbps')

--13	Display the package number, internet speed and monthly payment for all packages whose monthly payment 
	--is lower than the minimum monthly payment of packages with internet speed equals to “5Mbps” (Packages table).
SELECT pack_id, speed, monthly_payment
FROM packages
WHERE monthly_payment < (SELECT MIN(monthly_payment)
						 FROM packages
						 WHERE speed = '5Mbps')

--14	14.	Display the first name, monthly discount and package number for all customers whose monthly discount 
	--is lower than the average monthly discount, and whose package number is the same as customer named “Kevin”
SELECT First_Name, monthly_discount, pack_id
FROM customers
WHERE monthly_discount < (SELECT AVG(monthly_discount)
						  FROM customers) AND pack_id IN (SELECT pack_id
												          FROM customers
														  WHERE First_Name = 'Kevin')
------------------------------
--Write three correlated Subqueries: one in Select, one in Where and onE in Having.
--Subqueries in SELECT
SELECT First_Name, (SELECT p.monthly_payment
					FROM packages p
					WHERE p.pack_id=c.pack_id) AS Countmonthly_discount
FROM customers AS c
WHERE First_Name LIKE'P%'

--Subqueries in WHERE
SELECT First_Name, monthly_discount
FROM customers
WHERE monthly_discount IN (SELECT monthly_discount
						   FROM customers
					       WHERE Customer_Id = 100)

--Subqueries in Having
SELECT c.pack_id
FROM customers AS c
GROUP BY c.pack_id
HAVING (SELECT p.monthly_payment
		FROM packages AS p
		WHERE p.pack_id=c.pack_id)>(SELECT AVG(monthly_discount)
									FROM customers)

--Combine queries using in, Exists, Any, All (one query each).
--EXISTS
SELECT pack_id, speed
FROM packages AS p
WHERE EXISTS (SELECT Customer_Id
			  FROM customers AS c
			  WHERE c.pack_id=p.pack_id)
ORDER BY pack_id

--ALL
SELECT c.First_Name, c.Last_Name, c.monthly_discount
FROM customers c
WHERE monthly_discount >ALL (SELECT monthly_discount
							 FROM customers
							 WHERE c.pack_id=pack_id)

--ANY
SELECT First_Name, Last_Name
FROM customers
WHERE monthly_discount < ANY(	SELECT monthly_discount
								FROM customers
								WHERE pack_id = 7)

								
--CASE
SELECT p.speed, p.monthly_payment, (CASE s.sector_name
										WHEN 'Private' THEN 'Packet pentru sector privat'
										WHEN 'Business' THEN 'Packet pentru sector business'
									END) AS PacketType
FROM packages AS p
INNER JOIN sectors AS s ON p.sector_id=s.sector_id
