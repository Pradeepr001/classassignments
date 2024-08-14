use PracticeDb
CREATE TABLE employee (
    employee_id INT PRIMARY KEY IDENTITY(1,1), -- Auto-generated primary key
    name VARCHAR(50) NOT NULL,                -- Name cannot be NULL
    exp INT CHECK (exp >= 2),                 -- Experience cannot be less than 2
    salary DECIMAL(10, 2) CHECK (salary BETWEEN 12000 AND 30000), -- Salary between 12000 and 30000
    department_name VARCHAR(25) CHECK (department_name IN ('HR', 'Sales', 'Accts', 'IT')), -- Departments restricted
    manager_name VARCHAR(50)
);
-- Insert values into the employee table
INSERT INTO employee (name, exp, salary, department_name, manager_name)
VALUES 
('smith', 5, 15000.00, 'HR', 'John Smith'),
('steve', 3, 18000.00, 'Sales', 'Lisa White'),
('David', 7, 25000.00, 'IT', 'Emily Clark'),
('Diana', 2, 13000.00, 'Accts', 'Robert Miller'),
('Wilson', 4, 22000.00, 'HR', 'John Smith'),
('Frank Turner', 6, 19000.00, 'Sales', 'Lisa White'),
('Grace Lee', 8, 27000.00, 'IT', 'Emily Clark'),
('Hannah Adams', 3, 14000.00, 'Accts', 'Robert Miller');

select * from employee
--1 Dsiplay employee id , name , salary.
SELECT employee_id, name, salary
FROM employee;
--2 Display employee id , where Employee ID  , name where NAme of EMployee ,   salary Salary f EMployee shud be displayed
SELECT employee_id AS [Employee ID], 
       name AS [Name], 
       salary AS [Salary]
FROM employee;
--3 Display  name  salary and also incremented salary for all the employees
SELECT name, salary, salary + 1000 AS incremented_salary
FROM employee;
--4 Display Total salary dispursed for all the departments
SELECT department_name, SUM(salary) AS total_salary
FROM employee
GROUP BY department_name;
--5 Display total salary, maximum salary, Average salary given in all the deprtments
SELECT department_name,
       SUM(salary) AS total_salary,
       MAX(salary) AS max_salary,
       AVG(salary) AS avg_salary
FROM employee
GROUP BY department_name;
--6 Depending uopn salary, arrange the records 
SELECT *
FROM employee
ORDER BY salary;
--7 Give a unique sequence to all the employees
SELECT employee_id, name, salary,
       ROW_NUMBER() OVER (ORDER BY employee_id) AS unique_sequence
FROM employee;
--8 Depending uopn salary, giv ranking tp all the employees
SELECT employee_id, name, salary,
       RANK() OVER (ORDER BY salary DESC) AS salary_rank
FROM employee;
--9 Add one more column age in employees table
ALTER TABLE employee
ADD age INT;
--10 By default its value shud be 26
ALTER TABLE employee
ALTER COLUMN age SET DEFAULT 26;
--11 Its range is 26 - 60 What value will be there for the records for this column now. How can u put value 26 for all the records
UPDATE employee
SET age = 26
WHERE age IS NULL;
--12 how many departments are there in the department
SELECT COUNT(DISTINCT department_name) AS num_departments
FROM employee;
--13 Display all the names of the employees in upper case
SELECT UPPER(name) AS upper_case_name
FROM employee;
--14 DIsplay only the first four alphbets from all the names
SELECT LEFT(name, 4) AS first_four_characters
FROM employee;
--15 DIsplay the position of a in all the names
SELECT employee_id, name,
       CHARINDEX('a', name) AS position_of_a
FROM employee;
--16 Display total number of employees working in every department
SELECT department_name, COUNT(*) AS total_employees
FROM employee
GROUP BY department_name;
--17 Display total number of employees working for every Manager
SELECT manager_name, COUNT(*) AS total_employees
FROM employee
GROUP BY manager_name;
--18 DIsplay all the recirds where employee ID is 101, 102 or 110
SELECT *
FROM employee
WHERE employee_id IN (101, 102, 110);
--19 GIve all records where empl id is in between 101 and 100
SELECT *
FROM employee
WHERE employee_id BETWEEN 101 AND 100;
--20 Give all records where department is HR
SELECT *
FROM employee
WHERE department_name = 'HR';
--21 Give all records where department is HR or Accts
SELECT *
FROM employee
WHERE department_name IN ('HR', 'Accts');
--22 Give all records where name starts with A
SELECT *
FROM employee
WHERE name LIKE 'A%';
--23 GIve all records where name contains a
SELECT *
FROM employee
WHERE name LIKE '%a%';
--24 Give all records where average sales is less than 12000 department wise
SELECT department_name
FROM employee
GROUP BY department_name
HAVING AVG(salary) < 12000;
--25 Give all records where average sales is less than 12000 department wise
SELECT *
FROM employee
WHERE department_name <> 'Accts'
  AND (salary < 10000 OR salary > 20000);
