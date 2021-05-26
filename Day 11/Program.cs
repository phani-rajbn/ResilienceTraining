using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApps
{
    class Program
    {
        static void Main(string[] args)
        {
            //NewFeatures.UsingVarKeyword();
            //NewFeatures.UsingAnonymousTypes();
            //NewFeatures.LambdaExpression();
            //NewFeatures.ExtensionMethods();

            /////////////////DB Programming//////////////////////////////
            //ConnectedModel.ConnectToDB();//Without any object creation
            //////////////////Inserting record//////////////////////
            //var emp = new Employee//TODO: make the user enter the values...
            //{
            //    DeptId = 2,
            //    EmpAddress = "Pune",
            //    EmpID = 15,
            //    EmpName = "Soumya",
            //    EmpSalary = 55000,
            //    PhoneNo = "097868576554"
            //};
            //ConnectedModel.InsertEmployee(emp);
            ////////////////Updating Records/////////////////////////////
            var emp = new Employee//TODO: make the user enter the values...
            {
                DeptId = 2,
                EmpAddress = "Nashik",
                EmpID = 15,
                EmpName = "Soumya Khelkar",
                EmpSalary = 65000,
                PhoneNo = "093458576554"
            };
            ConnectedModel.UpdateEmployee(emp);
            //////////////////////Reading records///////////////////////
            //var data = ConnectedModel.GetAllEmployees();//Get All the Employees and display

            Console.WriteLine("Enter name or part of the name to search");//Find Employees with matching names
            var data = ConnectedModel.FindEmployee(Console.ReadLine());
            foreach(var temp in data)
                Console.WriteLine(temp);
            
        }
        //Create 3 Tables in UR SQL server: Employee, Dept and Project
        //Dept is referened in Employee, EmployeeID is referenced in Project. 

    }
}
