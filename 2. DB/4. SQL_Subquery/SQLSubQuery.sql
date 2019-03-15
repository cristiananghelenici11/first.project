--1.
SELECT [First_Name], [Last_Name], [City], [State]
FROM customers
WHERE 
	[State] = (
		SELECT [State] 
		FROM customers 
		WHERE [Customer_Id] = 170);

--2.
SELECT p.pack_id, p.speed, p.sector_id
FROM packages AS p
WHERE 
	sector_id = (
		SELECT sector_id
		FROM packages
		WHERE pack_id = 10
)

--3
SELECT First_Name, Last_Name, Join_Date
FROM customers
WHERE Join_Date = (
	SELECT Join_Date
	FROM customers
	WHERE Customer_Id = 540
);

--4
SELECT First_Name, Last_Name, Join_Date
FROM customers
WHERE MONTH(Join_Date) = (
	SELECT MONTH(Join_Date) AS MonthDate
	FROM customers 
	WHERE Customer_Id = 372) 
	AND
	YEAR(Join_Date) = (
	SELECT YEAR(Join_Date)
	FROM customers
	WHERE Customer_Id = 372)

SELECT First_Name, Last_Name, Join_Date
FROM customers,(SELECT YEAR(Join_Date) AS JoinYear, MONTH(Join_Date) AS JoinMonth
				FROM customers
				WHERE Customer_Id = 372) AS DateTemp
WHERE YEAR(Join_Date) = DateTemp.JoinYear AND MONTH(Join_Date) = DateTemp.JoinMonth

---5
SELECT [First_Name], [Last_Name], [City], [State], [pack_id]
FROM customers
WHERE customers.pack_id IN (
	SELECT pack_id
	FROM packages
	WHERE speed = '5Mbps')

--6
SELECT pack_id, speed, strt_date
FROM packages
WHERE YEAR(strt_date) = (
	SELECT YEAR(strt_date)
	FROM packages
	WHERE pack_id =7)

--7
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
--8

SELECT First_Name, monthly_discount, pack_id
FROM customers
WHERE pack_id IN (SELECT pack_id
					FROM packages
					WHERE monthly_payment > (SELECT AVG(monthly_payment) 
											FROM packages));

--9
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
--10
SELECT *
FROM packages
WHERE speed = ( SELECT speed
				FROM packages
				WHERE pack_id = 7)
