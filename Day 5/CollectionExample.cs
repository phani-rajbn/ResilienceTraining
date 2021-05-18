using System;
using System.Collections.Generic;//Since .NET 2.0. 
using System.Linq;//Introduced in .NET 3.5
/*
 * Arrays are fixed in size and they are immutable. 
 * U can only modify the elements of the array but U cannot dynamically add or remove the elements of the array and resize it. 
 * Arrays have fixed format of data structure. Elements are from top to bottom. It is hard to enforce strict Data Structure rules like First In First Out, Unique data and many more. 
 * List is a generic Collection class which works similar to array and performs adding, removing, inserting and other operations required. It adds the data to the bottom of the list. However U can insert in b/w. U cannot guarantee uniqueness of the data in the collection.  
 * HashSet is a generic Collection class that works similar to List but guarantees to store only unique data in it. Rest of its functionalities are similar to List<T>.
 *      HashSet uses Hash Value of an object and Equals function to determine the uniqueness of the object. If 2 Objectjs hashcode is different, it wont go to the Equals method. If the objects hashcode is same, then it goes to the Equals method to determine the object equivalence and then check the uniqueness of the object.  
 *      Every object that U create in .NET has a unique no stored in it called as HASHVALUE. U can get the value using System.Object's methods called GetHashCode. 
 * Dictionary is a generic collection class that stores pairs of data, in this the first value of the pair is called KEY which is said to be unique for the collection and other value is called VALUE which may not be unique. Storing the data in the form of KEY-VALUE pairs is what is called as Dictionary. Key is unique but VALUE may not be unique.
 * Queue is typically required when U want to have a first In First out kind of data structure. Recent Items in Flipkart is based on this principle. 
 */
namespace SampleConApp.Day_5
{
    class Item
    {
        public string ItemName { get; set; }
        public int Price { get; set; }
    }
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
            //DictionaryExample();
            //QueueExample();
            //StackExample();
        }

        private static void StackExample()
        {
            //Solitaire game is based on Stack.....
            Stack<string> books = new Stack<string>();
            books.Push("The Tale of Two cities");
            books.Push("The Tempest");
            books.Push("Malgudi Days");
            books.Push("A Suitable Boy");
            //One book will be placed above the other.
            foreach(var book in books)
                Console.WriteLine(book);
            var selected = books.Pop();//Remove the last item U have added to the Stack
            Console.WriteLine("This Book was selected as the last book: " + selected);
        }

        //TODO: Make this QueueExample an interactive program that will take inputs from the user and internally displays only 5 recently viewed items. 
        private static void QueueExample()
        {
            Queue<Item> items = new Queue<Item>();
            items.Enqueue(new Item { ItemName = "Apple", Price = 200 });
            items.Enqueue(new Item { ItemName = "Grapes", Price = 100 });
            items.Enqueue(new Item { ItemName = "Potatoes", Price = 20 });
            items.Enqueue(new Item { ItemName = "Onions", Price = 10 });
            foreach(var item in items)
                Console.WriteLine(item.ItemName);
            var data = items.Reverse();
            Console.WriteLine("UR recently viewed items.....");
            foreach (var item in data) { Console.WriteLine(item.ItemName); };
            items.Dequeue();//Always removes the first item in the queue...
            items.Enqueue(new Item { ItemName = "Oranges", Price = 65 });
            data = items.Reverse();
            Console.WriteLine("UR recently viewed items.....");
            foreach (var item in data) { Console.WriteLine(item.ItemName); };
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
