using System;

namespace SampleConApp.Day_5
{
    interface ICustomer
    {
        void Create();
    }

    interface IEmployee
    {
        void Create();
    }

    class CustomerEmployee : ICustomer, IEmployee
    {
        //Explicit implementation in Interface is a feature where U implement an interface method by specifically mentioning the name of the Interface for which U R implementing. 
        void IEmployee.Create() => Console.WriteLine("Employee is created");

        void ICustomer.Create() => Console.WriteLine("Customer is created");

        public void Create() => Console.WriteLine("Employee and Customer info is created");
    }
    class ExplicitImplementation
    {
        static void Main(string[] args)
        {
            IEmployee emp = new CustomerEmployee();
            emp.Create();

            ICustomer cst = new CustomerEmployee();
            cst.Create();

            CustomerEmployee empCst = new CustomerEmployee();
            empCst.Create();
        }
    }
}
