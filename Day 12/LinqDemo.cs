using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Stands for Language integrated Queries: Introduced in .NET 3.5.
 * It allows to perform queries like SQL server but on Objects of .NET using simplified syntax. It is based on Collections. U will perform queries on Collections. 
 * To do this, C# 3.5 introduced new keywords and features: select, group, by, order and features like var, anonymous types, lamdba expressions and so forth... 
 * LINQ was traditionally Read only. If U have a collection, the LINQ helps in performing queries not insertion, deletion or updation and even saving. 
 * To do that U can use database and XML files 
 * LINQ is available on XML called XLINQ. (Shared some examples)
 * LINQ on SQL server database is called as LINQ to SQL. LINQ to SQL is an ORM Framework. Object Relational Mapping. It is a Framework that will treat Tables as classes and its columns as properties and the data of those tables as Collections. 
 */

namespace DatabaseApps
{
    using System.IO;
    static class Database
    {
        private static List<Employee> _allEmployees = readFile();
        private static List<Employee> readFile()
        {
            List<Employee> temp = new List<Employee>();
            var lines = File.ReadAllLines("MockEmpRecords.csv");//Place the file in the executing dir
            foreach(String line in lines)
            {
                var words = line.Split(','); //split each line and extract the words
                Employee emp = new Employee//read each word and store it into different fields of the class
                {
                    EmpID = Convert.ToInt32(words[0]),
                    EmpName = words[1],
                    EmpAddress = words[2],
                    EmpSalary = Convert.ToDouble(words[3]),
                    PhoneNo = words[4],
                    DeptId = Convert.ToInt32(words[5])
                };
                temp.Add(emp);//Add the object to the list
            }
            //return the list
            return temp;
        }
        public static List<Employee> AllEmployees
        {
            get
            {
                return _allEmployees;
            }
        }
    }
    class LinqDemo
    {
        static List<Employee> list = Database.AllEmployees;

        public static void DisplayAllNames()
        {
            /*var results = from varName in collection
                            where | order by | group by | joins
                            select operation*/
            var names = from emp in list
                        select emp.EmpName;

            foreach (var name in names) Console.WriteLine(name);
        }

        public static void DisplayNameAndCity()
        {
            var info = from emp in list
                       select new { emp.EmpName, emp.EmpAddress };
            foreach(var detail in info)
            {
                Console.WriteLine($"{detail.EmpName} is from {detail.EmpAddress}");
            }
        }

        public static void WhereClauseDemo()
        {
            Console.WriteLine("Enter the City name");
            var city = Console.ReadLine();

            var selected = from emp in list
                           where emp.EmpAddress.ToUpper() == city.ToUpper() && emp.EmpName.Contains("Chandler")
                           select emp;//SELECT * From list WHERE EMPADDRESS = @city

            //LINQ Query will always return a collection.. U should do a foreach to fetch the record(s). 
            foreach(var rec in selected)
                Console.WriteLine(rec.EmpName + " from " + rec.EmpAddress);
        }

        public static void OrderByClauseDemo()
        {
            var records = from emp in list
                          orderby emp.EmpAddress, emp.EmpName
                          select new { Name = emp.EmpName, City = emp.EmpAddress };

            foreach (var name in records) Console.WriteLine($"{name.City}-{name.Name}");
        }

        public static void GroupByClause()
        {
            var records = from emp in list
                          group emp.EmpName by emp.EmpAddress into gr
                          orderby gr.Key descending
                          select gr;
            //Finally U get a collection of groups where each group has a collection of names...
            foreach(var gr in records)
            {
                Console.WriteLine("Employees from " + gr.Key);
                foreach(var name in gr)
                    Console.WriteLine(name);
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
