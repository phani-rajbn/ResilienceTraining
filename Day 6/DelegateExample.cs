using System;
/*
 * Delegates are similar to function pointers of C++. They are references to methods so that U can invoke them during runtime based on the function it is refering to. They are used to perform callback operations, async operations within an application.
 * Delegates are helpfull in creating methods that will take method as an arg instead of an object as an argument.
 * Delegates are reference types, so U can create instances of the delegates inr UR code. 
 * The method that U R passing to the delegate instance should have the same nomenclature. Its return type and its parametes must be matching to the delegate signature. 
 * 
*/
namespace SampleConApp.Day_6
{
    //Creating a Delegate
    delegate double ArithematicOperation(double v1, double v2);
    class DelegateExample
    {
        //to pass a method as an argument
        static void DoMathOperation(ArithematicOperation operation)
        {
            double first = MyConsole.GetDouble("Enter First Value");
            double second = MyConsole.GetDouble("Enter Second Value");
            double res = operation(first, second);//Invoking the passed method... 
            Console.WriteLine("The Result: " + res);
        }

        /*A function is required only when U want to invoke these statements multiple times within the application execution*/

        static double myFunc(double v1, double v2) => v1 * v2 - v1 + v2; 

        static void Main(string[] args)
        {
            /*****************Old Syntax******************************
            ArithematicOperation instance = new ArithematicOperation(myFunc);
            DoMathOperation(instance);
            **********************Different kind**********************************
            ArithematicOperation instance = myFunc;
            DoMathOperation(instance);
            **********************.NET 2.0*************************
            DoMathOperation(myFunc);
            ***************************Anonymous methods*********************
            DoMathOperation(delegate(double v1, double v2)
            {
                return v1 + v2;
            });

            DoMathOperation(delegate (double v1, double v2)
            {
                return v1 - v2;
            });
            *********************Using Lambda Expression******************************/
            DoMathOperation((v1, v2) => {
                Console.WriteLine("I am sitting inside a non informative method");
                return v1 - v2;
            });

            DoMathOperation((apple, mango) => apple - mango);
            //ToDo: convert all UR methods to lambda Expressions and see how it works.....
        }
    }
}
/*Delegates will be revisited while we do multi threading. */