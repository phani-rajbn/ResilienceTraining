using System;
using System.Collections.Generic;
//BookStore app will use all the features that we have learnt till now...

namespace SampleConApp.Day_5
{
    class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }
    interface IBookStore
    {
        void AddNewBook(Book bk);
        void UpdateDetails(Book bk);
        void DeleteBook(int id);
        List<Book> Find(string titlePart);
        Book Find(int id);
    }

    class BookStore : IBookStore
    {
        List<Book> _allBooks = new List<Book>();//No books....
        public void AddNewBook(Book bk)
        {
            _allBooks.Add(bk);
        }

        public void DeleteBook(int id)
        {
            Book bk = this.Find(id);
            if(bk != null)
                _allBooks.Remove(bk);
        }

        public List<Book> Find(string titlePart)
        {
            List<Book> _tempList = new List<Book>();
            foreach(var book in _allBooks)
            {
                if (book.Title.Contains(titlePart))
                {
                    _tempList.Add(book);
                }
            }
            return _tempList;
        }

        public Book Find(int id)
        {
            foreach(var book in _allBooks)//Iterate...
            {
                if(book.BookID == id)//Find the matching book based on id
                {
                    return book;//return the book....
                }
            }
            throw new Exception("Book not found");
        }

        public void UpdateDetails(Book bk)
        {
            //Iterate thro the collection
            for (int i = 0; i < _allBooks.Count; i++)
            {
                if(_allBooks[i].BookID == bk.BookID)//find the matching book
                {
                    _allBooks[i].Author = bk.Author;//update the details
                    _allBooks[i].Price = bk.Price;
                    _allBooks[i].Title = bk.Title;
                    return;//exit the function
                }
            }
            throw new Exception("Book not found to update");
        }
    }
    class BookStoreApp
    {
        static IBookStore store = new BookStore();
        static void Main(string[] args)
        {
            store.AddNewBook(new Book { BookID = 1, Author = "Shakespear", Price = 400, Title = "Romeo and Juiliet" });
            store.AddNewBook(new Book { BookID = 3, Author = "Vikram Seth", Price = 700, Title = "The Suitable Boy" });
            store.AddNewBook(new Book { Author = "C.Rajagopalachari", Title = "The MahaBharatha", Price = 250, BookID = 2 });
            //Compile time polymorphism
            var book = store.Find(MyConsole.GetNumber("Enter the ID of the book U want to Find"));
            Console.WriteLine("The Selected Book Title is " + book.Title);
            var search = store.Find("o");
            foreach (var bk in search) Console.WriteLine(bk.Title);
        }
    }
}
//Develop an App for maintaining lab tests within a Pathelogy Laboratory. U will store each test sample in ur application. A test Sample will contain an ID, Name(Blood Test, Urine Test, BloodSugar),  Result, Cost. No functionality for deleting a Sample in UR Application.