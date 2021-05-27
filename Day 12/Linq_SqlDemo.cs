using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
/*
 * LINQ will create a Class called DataContext that will be used to perform all operations like search, insert, delete, update the records and so forth. UR tables will be now classes and UR data will be objects of those classes.  
 * With ORM, U dont need to work on SQL statements, U could ur objects and its LINQ statements to get what data U want from the DB. As far as performance is concerned, still ADO.NET is faster than any other ORM frameworks. 
 */
namespace DatabaseApps
{
    static class Linq_SqlDemo
    {
        public static void DisplayNamesFromDB()
        {
            var context = new LinqOrmDataContext();//interface to interact with the collections...
            var names = from emp in context.tblEmployees
                        select new { emp.EmpName, emp.EmpAddress };
            foreach (var name in names) Console.WriteLine(name);
        }

        public static void DisplayNameAndDept()
        {
            var context = new LinqOrmDataContext();
            var records = from emp in context.tblEmployees
                          select new { emp.EmpName, emp.tblDept.DeptName };
            foreach (var rec in records) Console.WriteLine(rec);
        }

        public static void DisplayNameFromCity()
        {
            var context = new LinqOrmDataContext();
            Console.WriteLine("Enter the City Name");
            string city = Console.ReadLine();
            var query = from emp in context.tblEmployees
                        where emp.EmpAddress == city
                        select emp;

            foreach (var emp in query) 
                Console.WriteLine(emp.EmpName +" from " + emp.EmpAddress);
        }

        public static void bulkInsertion()
        {
            var data = Database.AllEmployees;
            var rows = from emp in data
                       select new tblEmployee//convert Employee object into tblEmployee
                       {
                           DeptId = emp.DeptId, EmpAddress = emp.EmpAddress, EmpID = emp.EmpID, EmpName = emp.EmpName, EmpPhone = emp.PhoneNo, EmpSalary = (decimal)emp.EmpSalary
                       };
            var context = new LinqOrmDataContext();
            context.tblEmployees.InsertAllOnSubmit(rows.ToList());
            context.SubmitChanges();
        }
        public static void InsertRecord()
        {
            var context = new LinqOrmDataContext();
            var newRec = new tblEmployee
            {
                DeptId = 2,
                EmpAddress = "Mandya",
                EmpID = 9,
                EmpName = "Gokul",
                EmpPhone = "04498767788",
                EmpSalary = 54000
            };
            try
            {
                context.tblEmployees.InsertOnSubmit(newRec);//adding the new object to the collection
                context.SubmitChanges();//This will do the job.
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error while inserting record");
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteRecord()
        {
            var context = new LinqOrmDataContext();
            var selected = context.tblEmployees.FirstOrDefault((emp) => emp.EmpID == 3);
            if (selected != null)
            {
                context.tblEmployees.DeleteOnSubmit(selected);
                context.SubmitChanges();
            }
        }

        public static void UpdateRecord()
        {
            var context = new LinqOrmDataContext();
            //query returns a collection if it is a single record.
            var query = from emp in context.tblEmployees
                      where emp.EmpID == 9
                      select emp;
            var updatingRec = query.First();//if a matching record is available it will return the object, else it will return null
            updatingRec.DeptId = 2;
            updatingRec.EmpAddress = "Mandya";
            updatingRec.EmpID = 9;
            updatingRec.EmpName = "Gokul";
            updatingRec.EmpPhone = "04498767788";
            updatingRec.EmpSalary = 54000;

            context.SubmitChanges();
            //find the rec with the matching id..
        }
    }
}
