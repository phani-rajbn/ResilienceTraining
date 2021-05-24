CREATE database SampleExample--Used to create a new database.
--Database name should be unique for a given SQL Server instance. 

Select Count(*) AS TOTAL from master.sys.databases

--STORED PROCEDURES are sp groups of statements that can be used like functions in ur application, U create once and use it many times, so that it optimises the code execution...
sp_databases;--SP to list all the databases of the current SQL instance. 

--TO delete an existing database U could use DROP statement.
DROP Database If exists SampleExample

--If EXISTS is used to check for the database before any operation is done...
--If U R using an existing DB, U cannot drop it, U should come out of the database and then drop it. 


Use SampleExample

--U should have the relevant privilages to do any kind of database programming. Technically U should be able to access the Master db and perform operations on it. U should be a DB Admin to do that job. 