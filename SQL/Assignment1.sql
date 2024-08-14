CREATE TABLE Worker (
    WORKER_ID INT PRIMARY KEY,
    FIRST_NAME CHAR(25) NOT NULL,
    LAST_NAME CHAR(25),
    SALARY INT CHECK (SALARY BETWEEN 10000 AND 25000),
    JOINING_DATE DATETIME,
    DEPARTMENT CHAR(25) CHECK (DEPARTMENT IN ('HR', 'Sales', 'Accts', 'IT'))
);
INSERT INTO Worker (WORKER_ID, FIRST_NAME, LAST_NAME, SALARY, JOINING_DATE, DEPARTMENT)
VALUES (1, 'John', 'Doe', 15000, '2016-06-11 00:00:00', 'HR'),
(2, 'kevin', 'kon', 19000, '2016-06-15 00:00:00', 'Accts'),
(3, 'steve', 'eliza', 20000, '2016-06-19 00:00:00', 'HR'),
(4, 'smith', 'ann', 19500, '2016-06-13 00:00:00', 'IT');

select * from Worker
--Write an SQL query to fetch “FIRST_NAME” from Worker table using the alias name as <WORKER_NAME>.
SELECT FIRST_NAME AS WORKER_NAME
FROM Worker;
-- Write an SQL query to fetch “FIRST_NAME” from Worker table in upper case.
SELECT UPPER(FIRST_NAME) AS FIRST_NAME_UPPER
FROM Worker;

--Write an SQL query to fetch unique values of DEPARTMENT from Worker table.
SELECT DISTINCT DEPARTMENT
FROM Worker;
--Write an SQL query to print the first three characters of  FIRST_NAME from Worker table.
SELECT SUBSTRING(FIRST_NAME, 1, 3) AS FIRST_NAME_PART
FROM Worker;
-- Write an SQL query to find the position of the alphabet (‘a’) in the first name column ‘Amitabh’ from Worker table.
SELECT CHARINDEX('a', FIRST_NAME) AS PositionOfA
FROM Worker
WHERE FIRST_NAME = 'Amitabh';
-- Write an SQL query to print the FIRST_NAME from Worker table after removing white spaces from the right side.
SELECT RTRIM(FIRST_NAME) AS TRIMMED_FIRST_NAME
FROM Worker;
--Write an SQL query to print the DEPARTMENT from Worker table after removing white spaces from the left side.
SELECT LTRIM(DEPARTMENT) AS TRIMMED_DEPARTMENT
FROM Worker;
--Write an SQL query that fetches the unique values of DEPARTMENT from Worker table and prints its length.
SELECT DISTINCT DEPARTMENT,
       LEN(DEPARTMENT) AS DEPARTMENT_LENGTH
FROM Worker;
--Write an SQL query to print the FIRST_NAME from Worker table after replacing ‘a’ with ‘A’.
SELECT REPLACE(FIRST_NAME, 'a', 'A') AS REPLACED_FIRST_NAME
FROM Worker;
--Write an SQL query to print the FIRST_NAME and LAST_NAME from Worker table into a single column COMPLETE_NAME. A space char should separate them.
SELECT FIRST_NAME + ' ' + LAST_NAME AS COMPLETE_NAME
FROM Worker;
--Write an SQL query to print all Worker details from the Worker table order by FIRST_NAME Ascending.
SELECT *
FROM Worker
ORDER BY FIRST_NAME ASC;
--Write an SQL query to print all Worker details from the Worker table order by FIRST_NAME Ascending and DEPARTMENT Descending.
SELECT *
FROM Worker
ORDER BY FIRST_NAME ASC, DEPARTMENT DESC;
--Write an SQL query to print details for Workers with the first name as “Vipul” and “Satish” from Worker table.
SELECT *
FROM Worker
WHERE FIRST_NAME IN ('Vipul', 'Satish');
--Write an SQL query to print details of workers excluding first names, “Vipul” and “Satish” from Worker table.
SELECT *
FROM Worker
WHERE FIRST_NAME NOT IN ('Vipul', 'Satish');
--Write an SQL query to print details of Workers with DEPARTMENT name as “Admin”.
SELECT *
FROM Worker
WHERE DEPARTMENT = 'Admin';
--Write an SQL query to print details of the Workers whose FIRST_NAME contains ‘a’.
SELECT *
FROM Worker
WHERE FIRST_NAME LIKE '%a%';
--Write an SQL query to print details of the Workers whose FIRST_NAME ends with ‘a’.
SELECT *
FROM Worker
WHERE FIRST_NAME LIKE '%a';
--Write an SQL query to print details of the Workers whose FIRST_NAME ends with ‘h’ and contains six alphabets.
SELECT *
FROM Worker
WHERE FIRST_NAME LIKE '_____h' -- 5 underscores + h
  AND LEN(FIRST_NAME) = 6;
--Write an SQL query to print details of the Workers whose SALARY lies between 100000 and 500000.
SELECT *
FROM Worker
WHERE SALARY BETWEEN 100000 AND 500000;
--Write an SQL query to print details of the Workers who have joined in Feb’2014.
SELECT *
FROM Worker
WHERE YEAR(JOINING_DATE) = 2014
  AND MONTH(JOINING_DATE) = 2;
--Write an SQL query to fetch the count of employees working in the department ‘Admin’.
SELECT COUNT(*) AS NumberOfEmployees
FROM Worker
WHERE DEPARTMENT = 'Admin';



