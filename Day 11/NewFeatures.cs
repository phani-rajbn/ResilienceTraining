using System;
using System.Collections.Generic;
using System.IO;

//Majority of these features first came up in .NET 3.5(2008) and was fully stablized in .NET 4.0(2010). 
namespace DatabaseApps
{
    static class MyExtensions
    {
        /*
         * Extension methods are added to the instance of the class, not to the class itself. 
         * Extension methods are always static and its first parameter will always be a reference of the class on which U wish to extend this method. 
         * U cannot have extension properties or fields. 
         * Extension methods are not the part of method overriding, so UR Runtime polymorphism wont work on extension methods.
         * Use extension methods for adding one or more functionality for existing class that cannot be extended. 
         * .NET when it introduced LINQ and new frameworks, it did not want to break the existing interfaces, so it added the new methods as extension methods to them. 
         */
        public static int GetWords(this String content)
        {
            var words = content.Split(',', ' ', '}', '{');
            return words.Length;
        }
    }
    class NewFeatures
    {
        internal static void UsingVarKeyword()
        {
            //In C# 3.0, var keyword was introduced. It is a convinient way of declaring local variables within ur code. It is also called as implicit typed variables. The var variable when declared will be assigned to any data, the data type of that data will be implicitly infered to the variable.
            //U must assign to the var variable while declaring itself.
            //var cannot be used as parameter or return type of a function
            //var is used only for local variables. 
            //var cannot be used as fields of a class. 
            //var automatically sets itself to the data type it is assigned to without knowing the actual type. Very helpful for storing return values of functions.
            //There is no need for boxing and unboxing in var like the way U do in objects.
            var intValue = 123;//integer.
            var stringValue = "Apple, Mango, Orange"; //convinience of declaring local variable
            var someValue = DateTime.Now ;
            Console.WriteLine(++intValue);
            Console.WriteLine(stringValue.ToUpper());
            Console.WriteLine(someValue.ToString("dd-MMM-yyyy"));

            var intArray = new int[] { 234, 45, 5, 454, 34 };
            foreach (var item in intArray) Console.WriteLine(item);
            Console.WriteLine("The size: " + intArray.Length);
        }

        internal static void ExtensionMethods()
        {
            String contents = File.ReadAllText("../../NewFeatures.cs");
            Console.WriteLine(contents.GetWords());
            
        }

        internal static void LambdaExpression()
        {
            //Lambda Expressions help in creating methods in a quick manner so that it can be used within a function or can be passed as an argument to a function. 
            List<String> fruits = new List<string>();
            fruits.Add("Apples");
            fruits.Add("Mangoes");
            fruits.Add("Oranges");
            fruits.Add("Bananas");
            fruits.Add("PineApples");
            fruits.Add("Grapes(White)");
            fruits.Add("Grapes(Purple)");
            fruits.Add("Lime");
            //List has funtions called Find, FindAll which takes a funtion as arg that defines the criteria of finding.
            //Find takes an instance of a delegate called Predicate which points to a function that defines the criteria of finding. This funtion will be called internally on every object of the List, whichever returns true will be the found object. 

            Console.WriteLine("Enter the Fruit to search");
            string name = Console.ReadLine();
            
            var foundFruit = fruits.Find((fruit) => fruit == name);
            Console.WriteLine(foundFruit);
            Console.WriteLine("Now trying to find all fruits matching a condition");
            Console.WriteLine("Enter the Fruit name or part of the name to search");
            name = Console.ReadLine();
            var foundFruits = fruits.FindAll((f) => f.Contains(name));
            foreach (var fruit in foundFruits) Console.WriteLine( fruit);
        }

        internal static void UsingAnonymousTypes()
        {
            //U have created an object of an unknown or anonymous type. There is no class created, but U have created an object using new operator. These objects are used to create on the fly objects for displaying purpose or reading purpose. Usually the data will be filled from a result of a Query from the Database or from a file.  
            //It will not have the features of OOP. No methods are creatable in these objects. They are simply data carriers. 
            var empDetails = new
            {
                EmpID = 123,
                EmpName ="Phaniraj",
                EmpAddress ="Bangalore"
            };
            Console.WriteLine(empDetails);
            Console.WriteLine($"The Name: {empDetails.EmpName}\nThe Address: {empDetails.EmpAddress}\nThe ID: {empDetails.EmpID}");
            Console.WriteLine("The data type: " + empDetails.GetType().Name);
        }
    }
}
