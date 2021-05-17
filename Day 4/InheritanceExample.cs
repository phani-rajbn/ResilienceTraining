using System;

namespace SampleConApp.Day_4
{
    /*
     * Inheritance is a feature of OOP based on the Open-Closed Principle of the SOLID principles of OOP. 
     * It promotes extending a class either by adding new features or modifying existing feature. It is not possible to do in the current class as according to the Open-Closed Principle, an existing class is closed for modification. 
     */

    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
    }

    //Syntax for extending the class in C#...
    class RegularEmployee : Employee
    {
        public DateTime DOB { get; set; }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - DOB.Year;
                return age;
            }
        } 
        public string Qualification { get; set; }
    }

    class InheritanceExample
    {
        static void Main()
        {
            //derived class object will get all the accessible members of the base class. 
            var emp = new RegularEmployee { DOB = DateTime.Parse("01/12/1976"), EmpAddress= "Bangalore", EmpId = 111, EmpName="Phaniraj", Qualification ="M.Sc"};

            //base class object will not get the members of the derived class. 
            var emp2 = new Employee { EmpId = 123, EmpName = "Chetan", EmpAddress = "Mysore" };


            Employee emp3 = new RegularEmployee { EmpId = 124, EmpAddress = "Chitradurga", EmpName = "Prajwal",  DOB = DateTime.Now.AddYears(-23), Qualification = "B.E" };
            Console.WriteLine(emp3.EmpName);
            //Console.WriteLine(emp3.DOB);//It wont work as the object is of the type Base class....

            //If a base class object is instantiated to the derived class, then the object will hide the members of the derived class. this feature is called Object Slicing. U should explicitly cast the object to the derived class and then use them members. In C#, U could use "is" and "as" operators to identify whether the base class object "is" instantiated to the derived class and then typecast it using the "as" operator.  
            if(emp3 is RegularEmployee)//safe way of casting. These operators are available only in C# language
            {
                var temp = emp3 as RegularEmployee;
                Console.WriteLine("The Age of this Employee is " + temp.Age);
            }
            else
            {
                Console.WriteLine("This employee is not a regular Employee");
            }
        }
    }
}
