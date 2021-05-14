using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp.Day_3
{
    class Customer
    {
        //Data members of the class, usually hidden from the rest of the world....
        private int _cstId;
        private string _cstBillingDate;
        private string _cstAddress;
        private double _billAmount;
        private DateTime _dateOfBilling; 

        public void SetDetails(int id, string BillingDate, string address, double amount, DateTime dt)
        {
            _cstAddress = address;
            _cstId = id;
            _cstBillingDate = BillingDate;
            _billAmount = amount;
            _dateOfBilling = dt;
        }

        //Properties are like functions but are used like fields which have get/set accessors

        public string CustomerBillingDate
        {
            get =>_cstBillingDate;
            set => _cstBillingDate = value;
        }
        public int CustomerID
        {
            get => _cstId;
            set => _cstId = value;
        }
       
        //Apply the properties for all fields of the class before U go for break... 
        public string CustomerAddress
        {
            get => _cstAddress;
            set => _cstAddress = value;
        }

        public DateTime BillingDate 
        {
            get => _dateOfBilling;
            set => _dateOfBilling = value;
        }

        public double BillingAmount
        {
            get => _billAmount;
            set => _billAmount = value;
        }

        public void AddAmount(double amount) => _billAmount += amount;
        
    }
    class ClassComposition
    {
        static void Main(string[] args)
        {
            Customer cst = new Customer();
            //This is how U set values to the properties:
            cst.CustomerID = 123;
            cst.CustomerBillingDate = "Phaniraj";
            cst.CustomerAddress = "Bangalore";
            cst.BillingAmount = 5600;
            cst.BillingDate = DateTime.Parse("24-03-2021");

            //Get the values from the properties
            Console.WriteLine($"The BillingDate of the customer is {cst.CustomerBillingDate}");
            Console.WriteLine($"The Address of the customer is {cst.CustomerAddress}");
            Console.WriteLine($"The BillAmount of the customer is {cst.BillingAmount}");
            Console.WriteLine($"The BillingDate of the customer is {cst.CustomerBillingDate}");
            Console.WriteLine($"The ID of the customer is {cst.CustomerID}");


        }
    }
}
