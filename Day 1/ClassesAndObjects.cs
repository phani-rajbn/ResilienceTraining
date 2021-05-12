using System;
/*
 * Class is a UDT that has both functions and data in it.
 * Comes with a host of features called OOP features. 
 * It is also called as Composite type. 
 * C# expects the code to be more class based(OOP based). 
 * To represent data that has multiple types of data, then u create a UDT called class.
 */
namespace SampleConApp
{
    class Book
    {
        public int BookID { get; set; }//new in C# 4.0
        public string Title { get; set; }//Automatic Properties in C#
        public string Author { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }

    class ClassesAndObjects
    {
        static void Main(string[] args)
        {
            //Book bk = new Book { BookID = 123, Author = "Phaniraj", Image = "", Price = 234560, Title = "C# Programming for Beginners" };
            ////This is called Instantiating and initializing the data of the object...
            //Console.WriteLine("The Title of the Book is {0} authored by {1} that costs {2:C}", bk.Title, bk.Author, bk.Price);
            const int bookCount = 4;
            Book[] allBooks = new Book[bookCount];
            for (int i = 0; i < bookCount; i++)
            {
                allBooks[i] = new Book
                {
                    BookID = MyConsole.GetNumber("Enter the ID"),
                    Title = MyConsole.Prompt("Enter the Title"),
                    Author = MyConsole.Prompt("Enter the AuthorName"),
                    Price = MyConsole.GetDouble("Enter the Cost of the book")
                };
            }
            Console.WriteLine("All Books are stored");
        }
    }
}
