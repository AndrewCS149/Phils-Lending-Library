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
        public Library<Book> Library { get; set; }
        public List<Book> BookBag { get; set; }

        static void Main(string[] args)
        {
            List<Book> bookBag = new List<Book>();
            Library<Book> library = new Library<Book>();

            LoadBooks(library);
            DisplayMenu(library, bookBag);
        }

        /// <summary>
        /// Adds a book from the library to the book bag
        /// </summary>
        /// <param name="title">Title of book</param>
        /// <param name="library">Library to pull book from</param>
        /// <param name="bookBag">Book bag to add to</param>
        public static void Borrow(string title, Library<Book> library, List<Book> bookBag)
        {
            foreach (Book book in library)
            {
                if(book.Title == title)
                {
                    Book newBook = new Book();
                    newBook.Title = title;
                    bookBag.Add(newBook);
                }
                else
                    Console.WriteLine("That book isn't in our library".);
            }
        }

        /// <summary>
        /// View all the books in the book bag
        /// </summary>
        /// <param name="bookBag">The book bag to view</param>
        public static void ViewBookBag(List<Book> bookBag)
        {
            foreach (Book book in bookBag)
            {
                Console.WriteLine(book.Title);
            }
        }

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
    }
}
