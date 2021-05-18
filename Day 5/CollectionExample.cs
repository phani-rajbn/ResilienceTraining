using System;
using System.Collections.Generic;//Since .NET 2.0. 
/*
 * Arrays are fixed in size and they are immutable. 
 * U can only modify the elements of the array but U cannot dynamically add or remove the elements of the array and resize it. 
 * Arrays have fixed format of data structure. Elements are from top to bottom. It is hard to enforce strict Data Structure rules like First In First Out, Unique data and many more. 
 * List is a generic Collection class which works similar to array and performs adding, removing, inserting and other operations required. It adds the data to the bottom of the list. However U can insert in b/w. U cannot guarantee uniqueness of the data in the collection.  
 * HashSet is a generic Collection class that works similar to List but guarantees to store only unique data in it. Rest of its functionalities are similar to List<T>.
 *      HashSet uses Hash Value of an object and Equals function to determine the uniqueness of the object. If 2 Objectjs hashcode is different, it wont go to the Equals method. If the objects hashcode is same, then it goes to the Equals method to determine the object equivalence and then check the uniqueness of the object.  
 *      Every object that U create in .NET has a unique no stored in it called as HASHVALUE. U can get the value using System.Object's methods called GetHashCode. 
 * Dictionary is a generic collection class that stores pairs of data, in this the first value of the pair is called KEY which is said to be unique for the collection and other value is called VALUE which may not be unique. Storing the data in the form of KEY-VALUE pairs is what is called as Dictionary. Key is unique but VALUE may not be unique
 */
namespace SampleConApp.Day_5
{
    class Employee
    {
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }

        public override int GetHashCode()
        {
            return EmpName.GetHashCode();//get the hashcode of EmpName. 
        }

        public override bool Equals(object obj)
        {
            if(obj is Employee)
            {
                var temp = obj as Employee;
                return ((EmpName == temp.EmpName) && (EmpAddress == temp.EmpAddress));
            }
            return false;
        }


    }
    class CollectionExample
    {
        static void Main(string[] args)
        {
            //listExample();
            //hashSetExample();
            //UniqueEmployeeCollection();
            DictionaryExample();
        }

        private static void DictionaryExample()
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            users.Add("Phaniraj", "apple123");

            if (users.ContainsKey("Phaniraj"))
                Console.WriteLine("User already exists");
            else
            {
                users["Phaniraj"] = "apple123"; //In this case, if the key already exists, it simply replaces the value else it adds to the dictionary. It will not throw any exception..
            }
        }

        private static void UniqueEmployeeCollection()
        {
            HashSet<Employee> myEmployees = new HashSet<Employee>();
            myEmployees.Add(new Employee { EmpName = "Phaniraj", EmpAddress = "Bangalore" });
            myEmployees.Add(new Employee { EmpName = "Phaniraj", EmpAddress = "Mysore" });
            myEmployees.Add(new Employee { EmpName = "Suresh", EmpAddress = "Bangalore" });
            myEmployees.Add(new Employee { EmpName = "Prajwal", EmpAddress = "Chitradurga" });
            myEmployees.Add(new Employee { EmpName = "Ramesh", EmpAddress = "Nellore" });
            myEmployees.Add(new Employee { EmpName = "Gopal", EmpAddress = "Chennai" });
            myEmployees.Add(new Employee { EmpName = "Swetha", EmpAddress = "Mysore" });
            if (!myEmployees.Add(new Employee { EmpName = "Swetha", EmpAddress = "Mysore" }))
                Console.WriteLine("Employee already exists");
            Console.WriteLine("The Count: " + myEmployees.Count);
        }

        private static void hashSetExample()
        {
            HashSet<string> basket = new HashSet<string>();
            basket.Add("Apples");
            if (basket.Add("Apples")) Console.WriteLine("Added");
            else
            {
                Console.WriteLine("Already exists");
            }
            Console.WriteLine("The No of Items: " + basket.Count);
        }

        private static void listExample()
        {
            List<string> basket = new List<string>();
            Console.WriteLine("The item Count: " + basket.Count);
            basket.Add("Apples");
            Console.WriteLine("The item Count: " + basket.Count);
            basket.Add("Mangoes");
            Console.WriteLine("The item Count: " + basket.Count);
            basket.Add("Oranges");
            Console.WriteLine("The item Count: " + basket.Count);
            basket.Add("Bananas");
            Console.WriteLine("The item Count: " + basket.Count);
            basket.Add("Kiwis");
            Console.WriteLine("The item Count: " + basket.Count);
            basket.Remove("Kiwis");
            Console.WriteLine("The item Count after removing: " + basket.Count);
            foreach (var item in basket)
            {
                Console.WriteLine(item.ToUpper());
            }
            //Explore on other functions of List like inserting, removing, removing at, cloning and iterating. 
        }
    }
}
