using System;
//SOLID Principles
/*
 * S->Single Responsibility Principle: Layerd architecture
 * Open-Closed Principle: Inheritance
 * L->Luskov's Substitution Principle: Polymorphism. 
 * Interface Segregation Principle: Interface Programming. 
 * Dependency Inversion Principle: Abstraction.
 */
//Every class should be unique.(Single Responsibility principle
//Principle in OOP called Open-Closed Principle. A Class is closed for modification but its open for extension.
//A Class is expecting to be immutable. 
//A Class is open for Extension. The Feature called Inheritance was included in the class...
namespace SampleConApp.Day_3
{
    class Apple
    {
        public void DisplayFruit() => Console.WriteLine("Apple is displayed"); 
        public virtual void TasteFruit() => Console.WriteLine("Tastes sweet");
    }

    class KashmirApple : Apple
    {
        public override void TasteFruit()
        {
            base.TasteFruit();//call the base version in ur code using base keyword...
        }
    }

    class OotyApple : KashmirApple
    {
        public override void TasteFruit() => Console.WriteLine("Tastes Tangy");
    }

    class OOPExample
    {
        static void Main(string[] args)
        {
            Apple instance = new KashmirApple();//Why create a variable of the type base class and instantiate it to the derived. 
            instance.TasteFruit();//Apple functionality
            instance = new OotyApple();
            instance.TasteFruit();//Derived Functionality
           
        }
    }
}
/*
 * Constituents of a Class:
 * Fields: Data members, usually private(They are available only within the class).
 * Properties: Acessors to the private Fields(They are public)
 * Methods: Functions that are used to manipulate the data of the class. 
 * Events: Actions performable on the objects.
 * Nested Classes: Class inside a class, used for app architectural point of view.
 */