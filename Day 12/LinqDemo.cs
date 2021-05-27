using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Stands for Language integrated Queries: Introduced in .NET 3.5.
 * It allows to perform queries like SQL server but on Objects of .NET using simplified syntax. It is based on Collections. U will perform queries on Collections. 
 * To do this, C# 3.5 introduced new keywords and features: select, group, by, order and features like var, anonymous types, lamdba expressions and so forth... 
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
    }
}
