create database testdb;
use testdb;


CREATE TABLE employees (
    emp_no      INT             NOT NULL,
    birth_date  DATE            NOT NULL,
    first_name  VARCHAR(14)     NOT NULL,
    last_name   VARCHAR(16)     NOT NULL,
    gender      ENUM ('M','F')  NOT NULL,    
    hire_date   DATE            NOT NULL,
    PRIMARY KEY (emp_no)
);
INSERT INTO employees (emp_no, birth_date, first_name, last_name, gender, hire_date) VALUES
(1, '1985-06-15', 'steve', 'T', 'M', '2010-05-01'),
(2, '1990-07-20', 'Smrithi', 'T', 'F', '2015-11-15'),
(3, '1982-12-25', 'nila', 'J', 'F', '2008-03-25'),
(4, '1988-09-05', 'vimal', 'm', 'M', '2012-07-10'),
(5, '1992-11-12', 'akhil', 'k', 'M', '2017-01-20');

CREATE TABLE departments (
    dept_no     CHAR(4)         NOT NULL,
    dept_name   VARCHAR(40)     NOT NULL,
    PRIMARY KEY (dept_no),
    UNIQUE  KEY (dept_name)
);
INSERT INTO departments (dept_no, dept_name) VALUES
('D001', 'Human Resources'),
('D002', 'Finance'),
('D003', 'Engineering'),
('D004', 'Sales');

CREATE TABLE dept_manager (
   emp_no       INT             NOT NULL,
   dept_no      CHAR(4)         NOT NULL,
   from_date    DATE            NOT NULL,
   to_date      DATE            NOT NULL,
   FOREIGN KEY (emp_no)  REFERENCES employees (emp_no)    ON DELETE CASCADE,
   FOREIGN KEY (dept_no) REFERENCES departments (dept_no) ON DELETE CASCADE,
   PRIMARY KEY (emp_no,dept_no)
); 
INSERT INTO dept_manager (emp_no, dept_no, from_date, to_date) VALUES
(1, 'D001', '2015-01-01', '2020-12-31'),
(2, 'D002', '2016-06-01', '2021-06-30'),
(3, 'D003', '2018-03-01', '2023-03-01');

CREATE TABLE dept_emp (
    emp_no      INT             NOT NULL,
    dept_no     CHAR(4)         NOT NULL,
    from_date   DATE            NOT NULL,
    to_date     DATE            NOT NULL,
    FOREIGN KEY (emp_no)  REFERENCES employees   (emp_no)  ON DELETE CASCADE,
    FOREIGN KEY (dept_no) REFERENCES departments (dept_no) ON DELETE CASCADE,
    PRIMARY KEY (emp_no,dept_no)
);
INSERT INTO dept_emp (emp_no, dept_no, from_date, to_date) VALUES
(1, 'D001', '2010-05-01', '2023-03-01'),
(1, 'D003', '2016-01-01', '2023-03-01'),
(2, 'D002', '2015-11-15', '2023-03-01'),
(3, 'D003', '2008-03-25', '2023-03-01'),
(4, 'D004', '2012-07-10', '2023-03-01'),
(5, 'D001', '2017-01-20', '2023-03-01');

CREATE TABLE titles (
    emp_no      INT             NOT NULL,
    title       VARCHAR(50)     NOT NULL,
    from_date   DATE            NOT NULL,
    to_date     DATE,
    FOREIGN KEY (emp_no) REFERENCES employees (emp_no) ON DELETE CASCADE,
    PRIMARY KEY (emp_no,title, from_date)
) ; 
INSERT INTO titles (emp_no, title, from_date, to_date) VALUES
(1, 'Senior Manager', '2015-01-01', '2023-03-01'),
(2, 'Finance Analyst', '2016-06-01', NULL),
(3, 'Lead Engineer', '2018-03-01', NULL),
(4, 'Sales Executive', '2012-07-10', NULL),
(5, 'Junior Analyst', '2017-01-20', NULL);
CREATE TABLE salaries (
    emp_no      INT             NOT NULL,
    salary      INT             NOT NULL,
    from_date   DATE            NOT NULL,
    to_date     DATE            NOT NULL,
    FOREIGN KEY (emp_no) REFERENCES employees (emp_no) ON DELETE CASCADE,
    PRIMARY KEY (emp_no, from_date)
) ; 
INSERT INTO salaries (emp_no, salary, from_date, to_date) VALUES
(1, 75000, '2015-01-01', '2022-12-31'),
(2, 55000, '2016-06-01', '2023-03-01'),
(3, 90000, '2018-03-01', '2023-03-01'),
(4, 60000, '2012-07-10', '2023-03-01'),
(5, 45000, '2017-01-20', '2023-03-01');
#1
USE testdb;
SELECT gender, COUNT(*) AS count
       FROM employees
       GROUP BY gender
       ORDER BY count DESC;
#2
USE testdb;
SELECT t.title, 
           ROUND(AVG(s.salary), 2) AS avg_salary
       FROM titles t
       JOIN salaries s ON t.emp_no = s.emp_no
       GROUP BY t.title
       ORDER BY avg_salary DESC;
#3
USE testdb;
SELECT e.first_name, 
           e.last_name, 
           COUNT(de.dept_no) AS num_departments
       FROM employees e
       JOIN dept_emp de ON e.emp_no = de.emp_no
       GROUP BY e.emp_no, e.first_name, e.last_name
       HAVING COUNT(de.dept_no) >= 2
       ORDER BY e.first_name ASC, e.last_name ASC;
#4
 USE testdb;
SELECT e.first_name, e.last_name, s.salary
       FROM employees e
       JOIN salaries s ON e.emp_no = s.emp_no
       WHERE s.salary = (
           SELECT MAX(salary)
           FROM salaries);
 #5      
USE testdb;
SELECT e.first_name, e.last_name, s.salary
FROM employees e
JOIN salaries s ON e.emp_no = s.emp_no
WHERE s.salary = (
           SELECT DISTINCT salary
           FROM salaries
           ORDER BY salary DESC
           LIMIT 1 OFFSET 1
       );
 #6      
use testDb;
select date_format(hire_date,'%Y-%m') as month,
count(*)as total_hires
from employees
group by month
order by total_hires desc
limit 1;
#7
use testDb;
select d.dept_name as department,
  min(timestampdiff(year,e.birth_date,e.hire_date)) as youngest_age_at_hire
  from employees e
  join dept_emp de on e.emp_no = de.emp_no
  join departments d on de.dept_no = d.dept_no
  group by d.dept_name;
  #8
  use testDb;
  select e.first_name,e.last_name,d.dept_name
  from employee e 
  join dept_emp de on e.emp_no = de.emp_no
  join departments d on de.dept_no = d.dept_no
  where e.first_name not regexp '[AEIOUaeiou]';