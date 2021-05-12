using System;
using kashmirApples = SampleConApp.Kashmir;
using OotyApples = SampleConApp.Ooty;

namespace SampleConApp
{
    namespace Kashmir
    {
        class Apple
        {
            public void Display() { Console.WriteLine("Kashmir Apple is displayed" ); }
        }
    }

    namespace Ooty
    {
        class Apple
        {
            public void Display() { Console.WriteLine("Ooty Apple is displayed"); }
        }
    }
    

    class Program
    {
        /*
         * Main is the entry point for any C# app directly or indirectly..
         * Its case sensitive. 
         * It can take only string array as its args or nothing.
         * Its a compile error if UR App does not have the Entry point.
         * Unlike C/C++, Main is a part of a class and it is static. 
         * U dont need an object to call the Main function.
         * C# claims to be pure object oriented Programming, everything is a part of either a class or a struct. 
         * It can take either void or int as return type, but it will be usually void.
         * On Console Apps, U interact with the Console using a Static class called Console defined under a namespace called System.
         * Namspaces are logical grouping that U do in ur application code to group ur classes so that U can avoid naming conflicts in the classes. 
         * VS Projects do create a namespace based on the Project Name for all the classes that U create in UR Project unless U deliberately create them without the namespaces.
         */
        static void Main(string[] args)
        {
            //kashmirApples.Apple apples = new Kashmir.Apple();
            //Ooty.Apple ootyApples = new Ooty.Apple();
            //firstExample();
            readingInputs();
        }
        //All inputs from the Console will be string only. So if U want to compute a result from the input, its good to create variables of specific types and do the computation. So U might end up converting strings to the respective types.
        private static void readingInputs()
        {
            Console.WriteLine("Enter UR name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the Date of Birth");
            string dob = Console.ReadLine();

            Console.WriteLine("Enter the Qualification");
            string qualication = Console.ReadLine();

            Console.WriteLine("The name is " + name);
            Console.WriteLine("{0}'s date of birth is on {1} and Mr.{0}'s qualification is {2}", name, dob, qualication);
            Console.WriteLine("The Date of Birth is {0}", dob);
            Console.WriteLine($"The Qualification is {qualication}");
        }

        private static void firstExample()
        {
            Console.WriteLine("Simple Text to be displayed on Console");
            Console.WriteLine(13000 + "Apple");
            Console.WriteLine(13.45345);
        }
    }
}
