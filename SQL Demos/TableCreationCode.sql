--Databases directly dont store any data in them. U need tables to store the data. Table is a datastructure with unique columns with specific data type info and rows that represent the data of the table.  Table is one of the most popular Data objects in SQL server. Any table should be created after U use a certain database in which U plan to create the table.
Create table tblEmployee
(
	EmpId int primary key,--ensures that this column's data is unique and must be set...
	EmpName varchar(100) not null,
	EmpAddress varchar(MAX) not null, 
	EmpContact bigint NOT NULL, -- large scale numbers.... 
	EmpSalary money NOT NULL --For currency data...
)
--Example to insert the record to the table...
Insert into tblEmployee values(1, 'Phaniraj', 'Bangalore', 09945205684, 65000);
Insert into tblEmployee values(3, 'Ramesh', 'Nellore', '081943453454', 65000);

--Modify the table for making changes to the table..
ALTER Table tblEmployee
Alter column EmpContact varchar(12) 
--U cannot change the name of the column. U can modify the datatype of the column, change the size, add a null or a not null rule(CONSTRAINT).

--Add a new column to the existing table....
Alter table tblEmployee
Add DeptName int

SELECT * FROM tblEmployee

Update tblEmployee Set deptName = 1 where EmpId > 0;

-- Drop the column of the table as long as its not related to another table...