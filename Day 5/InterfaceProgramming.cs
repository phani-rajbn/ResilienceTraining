using System;
/*
 * Interface is like an abstract class that has only abstract methods in them. It will not have implementations in any of its methods or properties. 
 * All interfaces are abstract classes but all abstract classes are not interfaces as abstract classes can have normal implemented methods.
 * In interface, the members are always public and U should not specify any access specifier. 
 * Interfaces cannot have fields, however U can have properties. 
 * If a class implements an interface, it must implement all the methods of the interface.
 * With interfaces, U can implement multiple interfaces at the same level, which is not possible with classes. This concept is called Multiple Inheritance which isnt supported in C#. C# supports only multiple interface inheritance. Only C++ supports multiple Inheritance.
 * According to the naming conventions of C#, U must prefix every interface with I.
 * Interfaces are more like contract where a class must implement the methods declared in the interface. U R binding to the rule of telling the system that if UR class implements an interface, U gaurentee that the methods of the interfaces are available with public scope in UR class. 
 * This feature is what makes interfaces the popular way of exposing in Frameworks and large scale application developments. 
 */
namespace SampleConApp.Day_5
{
    interface IExample
    {
        void ExampleFunc();
    }

    interface ISimple
    {
        void SimpleFunc();
    }

    //Which is the base class for this SimpleExample? in this case, the base class is System.Object. System.Object is the base class for all types in .NET/C#.
    class SimpleExample : IExample, ISimple
    {
        int data = 0;
        public void ExampleFunc()
        {
            data = 123;
            Console.WriteLine("Example Func is implemented") ;
        }

        public void SimpleFunc()
        {
            Console.WriteLine("Read the data: " + data);
            Console.WriteLine("Simple Func is implemented") ;
        }
    }
    class InterfaceProgramming
    {
        static void Main(string[] args)
        {
            IExample ex = new SimpleExample();
            ex.ExampleFunc();

            //ISimple sim = new SimpleExample();
            ISimple sim = (ISimple)ex;
            sim.SimpleFunc();

        }
    }
}
/*
 * Assignment: What are sealed classes in C#? R there any Sealed methods. Demonstrate it with an example.  
 */