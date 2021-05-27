using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApps
{
    static class Linq_SqlDemo
    {
        public static void DisplayNamesFromDB()
        {
            var context = new LinqOrmDataContext();//interface to interact with the collections...
            var names = from emp in context.tblEmployees
                        select emp.EmpName;
            foreach (var name in names) Console.WriteLine(name);
        }
    }
}
