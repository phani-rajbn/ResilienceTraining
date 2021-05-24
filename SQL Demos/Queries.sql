--Queries Example--------
use SampleExample

--Adding a row to the table.
Insert into tblEmployee values(14, 'Anjan', 'Mumbai', '0987546574334', 40000, 3)
--If U want to insert to specific columns and in an unordered way.....
Insert into tblEmployee(EmpId, EmpName, EmpAddress, EmpContact, EmpSalary) values(5, 'Kasturi', 'Gadag', '02343444234', 70000);  
--U cannot insert a value to IDENTITY Column(Auto generating column). It is good to specify the column names and then values to it using insert into tablename(cols) values(); The result window displaying as the no of rows affected will determine the success of the insertion. 
--Inserting to a row and extract the auto generated value...
Insert into tblEmployee(EmpName, EmpAddress, EmpSalary, EmpContact)
OUTPUT inserted.EmpId
VALUES('Charan', 'Chitoor', 76000, '34234245562')

--U can set values to the IDENTITY COLUMN by setting the IDENTITY_INSERT tblEmployee ON;
SET IDENTITY_INSERT tblEmployee ON
Insert into tblEmployee(EmpId, EmpName, EmpAddress, EmpSalary, EmpContact, DeptName) values(14, 'Anjan', 'Mumbai', '0987546574334', 40000, 3)

SET IDENTITY_INSERT tblEmployee OFF -- If U want to allow the SQL server to set the auto generated value back
Insert into tblEmployee values
(
'Gopal','Mysore','0989796555',55000, 2
),
(
'Vishnu','Mysore','0989796555',50000, 2
),
(
'Ananth','Shimoga','32154687',55000, 2
),
(
'Shankar','Hubli','78955578',55000, 2
)
SELECT * FROM tblEmployee

create table CityInfo(
	CityID int primary key identity,
	CityName varchar(100)
)
---Inserting records into one table based on the data from the other table....
Insert into CityInfo(CityName)
SeleCT Distinct EmpAddress from tblEmployee order by EmpAddress

-------------------------------Update Queries------------------------------------------
Update tblEmployee Set EmpAddress = 'Bengaluru' where EmpAddress ='Bangalore';
Update tblEmployee Set EmpAddress = 'Chitradurga' where EmpAddress ='Durga';

Update CityInfo set CityName = 'Bengaluru' where CityID = 1 
--------------------SELECT Queries-------------------------------------------------
SELECT * FRom CityInfo