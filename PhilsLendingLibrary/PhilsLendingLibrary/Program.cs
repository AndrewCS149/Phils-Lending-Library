using PhilsLendingLibrary.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using static PhilsLendingLibrary.Classes.UserInterface;
using static PhilsLendingLibrary.Classes.Author;
using static PhilsLendingLibrary.Classes.Book;

namespace PhilsLendingLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> book = new List<Book>();
            Library<Book> library = new Library<Book>();

            LoadBooks(library);
            DisplayMenu(library);
        }

        public Library<Book> Library { get; set; }
        public List<Book> BookBag { get; set; }



        /// <summary>
        /// Prepares initial books to load into bookbag
        /// </summary>
        /// <param name="book">bookBag to load books into</param>
        static void LoadBooks(Library<Book> library)
        {
            Book book1 = new Book()
            {
                Author = new Author()
                {
                    FirstName = "John",
                    LastName = "Tolkien",
                    DOB = new DateTime(1892, 1, 03)
                },

                Title = "Fellowship of the Ring",
                NumberOfPages = 350,
            };

            Book book2 = new Book()
            {
                Author = new Author()
                {
                    FirstName = "John",
                    LastName = "Tolkien",
                    DOB = new DateTime(1892, 1, 03)
                },

                Title = "The Two Towers",
                NumberOfPages = 350,
            };

            Book book3 = new Book()
            {
                Author = new Author()
                {
                    FirstName = "John",
                    LastName = "Tolkien",
                    DOB = new DateTime(1892, 1, 03)
                },

                Title = "Return of the King",
                NumberOfPages = 350,
            };

            library.Add(book1);
            library.Add(book2);
            library.Add(book3);
        }


        //static void ReturnBook(List<Book> bookBag, Library<Book> library)
        //{
        //    Dictionary<int, Book> books = new Dictionary<int, Book>();
        //    Console.WriteLine("Which book would you like to return");
        //    int counter = 1;
        //    foreach (var item in bookBag)
        //    {
        //        books.Add(counter, item);
        //        Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

        //    }

        //    string response = Console.ReadLine();
        //    int.TryParse(response, out int selection);
        //    books.TryGetValue(selection, out Book returnedBook);
        //    bookBag.Remove(returnedBook);
        //    library.Add(returnedBook);
        //}

        //static void AddABook(string title, string firstName, string lastName, int numberOfPages, Genre genre, Library<Book> library)
        //{
        //    Book book = new Book()
        //    {
        //        Title = title,
        //        Author = new Author()
        //        {
        //            FirstName = firstName,
        //            LastName = lastName
        //        },
        //        NumberOfPages = numberOfPages,
        //        Genre = genre
        //    };

        //    library.Add(book);
        //}
    }
}
