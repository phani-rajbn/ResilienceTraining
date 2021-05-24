sp_tables--Displays all the tables and its schema

--* is a wild charecter to select all the columns of the table..
SELECT * FROM Sales.Customers
--Dont Use * unless U R required to populate all the data to the front end(Application).
--The result from the SELECT statement is called RESULT SET. 
Select first_Name, last_name, email from Sales.Customers

SELECT COUNT(*) As CustomerCount from Sales.Customers

-------------------WHERE CLAUSE-------------------------------------
SELECT * FROM Sales.Customers where City = 'Encino'

--When a where clause is available, SQL will process the query as FROM->WHERE->SELECT.
SELECT * FROM SALES.Customers where State = 'CA'

---------------------------ORDER BY-----------------------------------
SELECT * FROM Sales.Customers where state ='CA' order by first_name

--------------------GROUP BY CLAUSE--------------------------------
SELECT City, Count(*) as CustomerCount From Sales.Customers
Where State = 'CA'
Group by city --group By will be done on the column that U have selected. 
Order by CustomerCount DESC

-----Get All Cities who have customers less than 6....
SELECT City, Count(*) as CustomerCount From Sales.Customers
Where State = 'CA'
Group By City
Having Count(*) > 5 --where of group by clause
Order by CustomerCount desc --DESC | ASC

---Get the Count of Distinct Cities in the Customers table. 
--Distinct is used to get unique collection
--Count is a scalar function that returns the no of elements the selected Query result.
Select Count(Distinct City) from Sales.Customers

Update Sales.Customers Set State = 'CA' WHere State = 'KAR'; 

SELECT City, first_name, last_name from sales.customers
order by city, first_name

---------------Using OFFSET and FETCH-----------------
select Top 10 product_name, list_price from production.products
order by list_price, product_name;

--Skip first 10 products and display the rest
select product_name, list_price from production.products
order by list_price, product_name
offset 10 rows
fetch next 10 rows only


--JOINS, Stored Procedures, Scalar Function, DateTime operations, Trigggers. 

