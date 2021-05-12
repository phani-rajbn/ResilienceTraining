using System;
//When U develop an App, the code should be cleanly separated and each function should do one task. This concept is called "SEPARATION OF CONCERNS"
namespace SampleConApp
{
    /*
     * C# has 2 types of data: Value types and Reference types
     * Value Types are structs and reference types are classes. 
     * Value types: 
     * Integral: byte(Byte), short(Int16), int(Int32), long(Int64)
     * Floating: float(Single), double(Double), decimal(Decimal)
     * Other: char(Char), bool(Boolean),
     * UDTs: enums and structs
     * All reference types are classes.
     * There are wrapper classes created by .NET for conversion purposes for every value type.
     * Parse method is used to convert string to its type. 
     * There will 
     */

    class MyConsole
    {
        public static void Print(string content)
        {
            Console.WriteLine(content);
        }
        public static string Prompt(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static int GetNumber(string question)
        {
            return int.Parse(Prompt(question));
        }

        public static double GetDouble(string question)
        {
            return double.Parse(Prompt(question));
        }
    }


    class DataTypes
    {

        static double getResult(double firstValue, double secondValue,string operand)
        {
            double result = 0;
            switch (operand)
            {
                case "+":
                    result = firstValue + secondValue;
                    break;
                case "-":
                    result = firstValue - secondValue;
                    break;
                case "*":
                    result = firstValue * secondValue;
                    break;
                case "/":
                    result = firstValue / secondValue;
                    break;
                default:
                    break;
            }
            return result;
        }
        static void Main()//(15 min)
        {
            //Task: Find all the Wrapper classes for the value types and develop a program to take inputs from the user and display the computed values based on addition, subtraction, multiplication and division.
            //3 inputs: 2 values(int), 1 operand(string)
            //Console.WriteLine("Enter value 1");
            //double firstValue = double.Parse(Console.ReadLine());

            double firstValue = MyConsole.GetDouble("Enter the First Value");

            double secondValue = MyConsole.GetDouble("Enter the Second Value");

            string operand = MyConsole.Prompt("Select the operand as +, -, *, /"); 

            double result = getResult(firstValue, secondValue, operand);//intialize the variables that U create...

            MyConsole.Print("The Result: " + result);
        }
    }
    /*
     * Converting from one type to another is done using static class called Convert. 
     * U can also use C Style casting for conversion, however they are not safe as it might end up giving abnormal results. 
     * If the conversion fails, it would throw us an Exception which could be caught and handled. 
     */
    
}
