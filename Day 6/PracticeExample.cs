using System;
namespace SampleConApp
{
    class PracticeExample
    {
        static int getMax(int[] arg)
        {
            int max = 0;
            foreach(int element in arg)
            {
                if (element > max)
                    max = element;
            }
            return max;
        }

        static void Main(string[] args)
        {
            //create a function that takes int array as arg and the function should return the max value of that array. Call the function in the main and display the result..Question to Sandeep.
            //sandeepExample();

            //create a function that takes id, name, address as arg and returns an object of a class called Person who has properties called PersonID, Name, Address. Call this function in the Main function and display the details of the Person: Sumithra.
            sumithraExample();
        }

        private static void sumithraExample()
        {
            Person p = createPerson(123, "Phaniraj", "Bangalore");
            Console.WriteLine($"The Name: {p.Name} is from {p.Address} and has SS ID as {p.PersonId}");
        }
        //Factory pattern
        private static Person createPerson(int id, string name, string addr)
        {
            Person p = new Person
            {
                PersonId = id, Address = addr, Name = name
            };
            return p;
        }

        private static void sandeepExample()
        {
            int max = getMax(new int[] { 145, 56, 467, 43, 55 });
            Console.WriteLine(max);
        }
    }

    class Person
    {
        public String Address { get; set; }
        public string Name { get; set; }
        public int PersonId { get; set; }
    }
}
/*
 * Write a program to read contents of a text file and display it.
 * Write a program to take a string as arg and returns the no of words in the string. 
 * Write a program to return a List<Book> by taking inputs from the User. 
 * Write a program to develop a Currency Converter which converts a certain amount from one currency to another: $, Pound, Euro and Rupee.
 */