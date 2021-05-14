using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Method or function of a class is used to manipulate or compute the private data of the class. It is also called as Operations of the class. There are static methods, instance methods, constructors and destructors. 
 * Methods can have inputs in the form of arguments and the output of the methods are in the form of return values. 
 * Arguments or parameters are dependency injectors of the methods. data that is required for the method to perform in the required manner is called as dependencies and U inject the dependencies to the method in the form of arguements. 
 * static methods are those methods that are used very frequently in the program without a need of an object. If the method is used frequently, then U can call those methods. static methods behave like global objects. static methods are internally singleton, one reference of it remains in the whole App instance. 
 * instance methods are always relative to the object that U have created. Details of one employee should not intefere with the details of other employee. This is called instance based.
 * If u want to return multiple values in a function U can do that using ref and out parameters. The difference is out parameters are not initialized but ref parameters are initialized before its passed to the function
 * For creating a method that takes different values that U can use params parameter
 * For creating objects of a class, U can use sp method called constructors. constructors are methods that are used to construct an object so that it can be usable. They have some rules: Name of the constructor method should be the name of the class, it cannot have any return type(not even void), it can be parameterized. constructors with no args are called as Default constructors and with args are called parameterized constructors. 
 * Typically for C#, U dont need constructors as the members of the class are defaultly initialized. Using initialization syntax (C# 4) U can set the properties and data members using {} braces.  But if U want to instantiate reference data members, then U may need the constructors. Constructors in C# are helpfull only if U R implementing HAS-A relationship in ur classes instead of IS-A relationship. 
 * Destructors in C# are used as functions that are invoked when the object is destroyed from the memory process. But C# or .NET does not support explicit object destruction like C/C++'s free and delete operators. .NET has Garbage collector, a component that takes care of memory management of reference types if there is a shortage of memory.  
 */
namespace SampleConApp.Day_3
{
    class Radio
    {
        public string Name { get; set; }
        public void Play() => Console.WriteLine($"{Name} is playing");
    }
    class Car 
    {
        private Radio _device;

        //constructor so that when the car is created, radio is either set or will have a default radio

        public Car(Radio radio)
        {
            if(radio == null)
                Console.WriteLine("This car is a base model");
            else
            {
                _device = radio;
                Console.WriteLine("This car is a fully loaded model");
            }
        }
        ~Car() => Console.WriteLine("Car is removed");
        public void Run()
        {
            Console.WriteLine("Car is running!");            
        }
        public void PlayMusic()
        {
            if (_device != null)
            {
                Console.WriteLine("Car is playing Radio:");
                _device.Play();
            }
        }
    }
    class Methods
    {
        static int AddMethod(int v1, int v2) => (v1 + v2);

        static int AddMethodWithMultipleValues(params int[] args)
        {
            var res = 0;
            foreach (var val in args)
                res += val;
            return res;
        }
        static void mathOperation(int v1, int v2, out int res1, out int res2)
        {
            res2 = v1 + v2;
            res1 = v1 * v2;
        }
        static void Main(string[] args)
        {
            //var res = AddMethod(123, 234);
            //Console.WriteLine("THE RESULT: " + res);
            ///////////////////ref and out parameters//////////////////////////////////////////
            int v1 = 123, v2 = 234;
            int res1, res2;//out parameters dont need initialized.
            mathOperation(v1, v2, out res1, out res2);
            //values set within the function will be retained even after the function returns, this is pass by reference in C#....
            // Console.WriteLine($"The Multiplied value {res1} and added value {res2}");

            ////////////////////////////params/////////////////////////////////////////
            /*
             * There should be only one params for a method
             * It should be the last of the parameter list.
             * params are always passed by value. 
             */
            res1 = AddMethodWithMultipleValues(1, 2, 3, 4, 5);
            //Console.WriteLine(res1);
            ////////////////////////Constructors///////////////////////
            //Car car = new Car(null);
            Car car = new Car(new Radio { Name = "PHILIPS"});
            //car.Run();
            //car.PlayMusic();

            for (int i = 0; i < 5; i++)
            {
                Car cr = new Car(new Radio { Name = " JBL" });
                cr.PlayMusic();
                GC.Collect();
            }
            Console.WriteLine("All cars are destroyed");
        }
    }
}
