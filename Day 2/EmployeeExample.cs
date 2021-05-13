using System;
using System.Data;
using System.IO;//For File reading....
/*
 * how to create a Class in C#
 * how to create arrays in C#
 * how to work with statements and expressions:switch, if, do...while, for..., foreach...
 */
/*
 * Single Responsibility Principle: Each class should do only one job. Dont mix everything into 1. Divide Ur Application. This is also called as Seperation of Concerns. UR App should be divided into multiple projects like DLLs, Services, Applications and UserInterfaces. 
 * Dlls are not executables. Services are executables that run behind the scenes.
 * Applications and User interfaces are the one that represents the End User's Stand point. 
*/

namespace SampleConApp
{
    //There is a very little purpose of a constructors in C# unless U R implementing HAS-A relationship in ur code. This class represents the Entity of the App. Entity classes are data carriers
    class Employee 
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public double EmpSalary { get; set; }
    }

    //This is the class used to interact with the storage layer: file, memory, database, cloud, external locations. This is called as Business Layer or BAL. In this example, the EmployeeCollection stores the data in the memory of the application, so the data will be lost after the App closes...
    class EmployeeCollection 
    {
        private Employee[] employees = new Employee[10];
        public void AddNewEmployee(Employee emp)
        {
            for (int i = 0; i < 10; i++)
            {
                if(employees[i] == null)
                {
                    employees[i] = new Employee
                    {
                        EmployeeId = emp.EmployeeId,
                        EmployeeName = emp.EmployeeName,
                        EmployeeAddress = emp.EmployeeAddress,
                        EmpSalary = emp.EmpSalary
                    };
                    return; //exit after setting the values in the array..
                }
            }
            
        }

        public void DeleteEmployee(int empId) 
        {
            //iterate thro the array using for loop
            for (int i = 0; i < employees.Length; i++)
            {
                //find the matching non null employee object whose ID is empId
                if((employees[i] != null) && (employees[i].EmployeeId == empId))
                {
                    //delete the object from the array
                    //.NET does not allow explicit deletion of the object...
                    employees[i] = null;//U simply assign it to null
                    return;//exit the function....
                }
            }
        }
        //Complete this example.....
        public void UpdateEmployee(Employee emp) 
        {
            throw new Exception("Do It Urself!!!!!");
        }

        public Employee[] GetAllEmployees() { return employees; }

    }

    //This is the service layer or the DAL....
    class EmployeeService
    {
        public void AddNewEmployee(int id, string name, string address, string salary)
        {
            //Code to save it to the data source....
        }

        public void DeleteEmployee(int empId) { }

        public void UpdateEmployee(int id, string name, string address, string salary) { }

        public DataTable GetAllEmployees() { return null; }
    }

    class EmployeeUI 
    {
        static EmployeeCollection collection = new EmployeeCollection();
        //Args of the Main function is used to pass Cmd line args for the application. Cmd line args are values that U want to pass for the application start up when its executed from the Cmd Prompt...
        //In VS, U can set the CmdLine arg in the Project->Properties->Debug->Command Line args....
        static void Main(string[] args)
        {
            string contents = File.ReadAllText(args[0]);
            bool operating = true;
            do
            {
                int choice = MyConsole.GetNumber(contents);
                operating = processMenu(choice);
            } while (operating == true);
        }

        //break, continue, return, throw, goto..
        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    addingEmployeeHelper();
                    break; ;
                case 2:
                    deletingEmployeeHelper();
                    break;
                case 3:
                    updatingEmployeeHelper();
                    break;
                case 4:
                    findingEmployeeHelper();
                    break; 
                default:
                    Console.WriteLine("Thank You for Using our Application");
                    return false;
            }
            return true;
        }

        private static void findingEmployeeHelper()
        {
            var allRecords = collection.GetAllEmployees();
            var empId = MyConsole.GetNumber("Enter the Id of the Employee to find");
            foreach (var emp in allRecords)
            {
                if((emp != null) && (emp.EmployeeId == empId))
                {
                    MyConsole.Print($"The Employee Name {emp.EmployeeName} is from {emp.EmployeeAddress} and his salary is {emp.EmpSalary:C}");
                    return;//exit the function as U dont have to continue the loop...
                }
            }
        }

        private static void updatingEmployeeHelper()
        {
            var emp = createEmployee();
            collection.UpdateEmployee(emp);
            Console.WriteLine("Employee updated to the System");
        }

        private static Employee createEmployee()
        {
            //code to take inputs from the user
            var id = MyConsole.GetNumber("Enter the Employee ID");
            var name = MyConsole.GetString("Enter the Employee Name");
            var address = MyConsole.GetString("Enter the Address");
            var salary = MyConsole.GetDouble("Enter the Salary");
            //create the Employee object
            var emp = new Employee
            {
                EmployeeAddress = address,
                EmployeeId = id,
                EmployeeName = name,
                EmpSalary = salary
            };
            return emp;
        }

        private static void deletingEmployeeHelper()
        {
            var empId = MyConsole.GetNumber("Enter the Id of the Employee to delete");
            collection.DeleteEmployee(empId);
            Console.WriteLine("Employee deleted successfully from the System");
        }

        private static void addingEmployeeHelper()
        {
            //code to take inputs from the user
            var emp = createEmployee();
            //call the add method of the Employee Collection
            collection.AddNewEmployee(emp);
            Console.WriteLine("Employee added successfully to the System");
        }
    }
}
