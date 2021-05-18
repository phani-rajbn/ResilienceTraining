using System;

//Exceptions are abnormal conditions raised due to some wrong scenarios or inputs given by the End user which UR application do not wish to continue or move forward. Exceptions can be system generated or App generated. System Generated Exceptions are filenotfound, divideByZero, KeyAlreadyExists and many more. 
//Application programmers can create their own exceptions and allow the end programmer to handle it. 
//Raising of Exceptions is done using throw followed by the instance of an Exception Class. 
//Exceptions are caught using try...catch blocks. Optionally U can have finally block also. 
namespace SampleConApp.Day_5
{
    class ExceptionHandling
    {
        static void Main(string[] args)
        {
            RETRY:
            try
            {
                Console.WriteLine("Enter a number to add");
                int number = int.Parse(Console.ReadLine());   
            }
            catch(FormatException)
            {
                Console.WriteLine("U must enter only whole numbers");
                goto RETRY;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Value should be b/w " + int.MinValue + " and " + int.MaxValue);
                goto RETRY;
            }
            //How to log the Exceptions raised by the Application....
        }
    }
}
