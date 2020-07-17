using PhilsLendingLibrary.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using static PhilsLendingLibrary.Classes.UserInterface;
using static PhilsLendingLibrary.Classes.Author;
using static PhilsLendingLibrary.Classes.Book;
using System.Threading;

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
            StartApplication(library, bookBag);
        }

        /// <summary>
        /// Adds a book from the library to the book bag
        /// </summary>
        /// <param name="title">Title of book</param>
        /// <param name="library">Library to pull book from</param>
        /// <param name="bookBag">Book bag to add to</param>
        public static void Borrow(string title, Library<Book> library, List<Book> bookBag)
        {
            Console.Clear();
            ViewBooks(library);
            foreach (Book book in library)
            {
                if (book.Title.ToLower() == title.ToLower())
                {
                    library.Remove(book);
                    bookBag.Add(book);
                    return;
                }
            }
            Console.Clear();
            Console.WriteLine("That book isn't in our library: Redirecting to home...");
            Thread.Sleep(2500);
            Console.Clear();
        }

        /// <summary>
        /// View all the books in the book bag
        /// </summary>
        /// <param name="bookBag">The book bag to view</param>
        public static void ViewBookBag(List<Book> bookBag)
        {
            if (bookBag.Count == 0)
            {
                Console.WriteLine("Your book bag is empty.");
                Thread.Sleep(2000);
            }
            else
            {
                int count = 1;
                foreach (Book book in bookBag)
                {
                    Console.WriteLine($"{count++}) {book.Title} - {book.Genre} - {book.Author.FirstName} {book.Author.LastName}");
                }
                Console.WriteLine();
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
                Genre = genre.Fantasy,
                Title = "Fellowship of the Ring",
                NumberOfPages = 350,
            };
            library.Add(book1);

            Book book2 = new Book()
            {
                Author = new Author()
                {
                    FirstName = "John",
                    LastName = "Tolkien",
                    DOB = new DateTime(1892, 1, 03)
                },
                Genre = genre.Fantasy,
                Title = "The Two Towers",
                NumberOfPages = 350,
            };
            library.Add(book2);

            Book book3 = new Book()
            {
                Author = new Author()
                {
                    FirstName = "John",
                    LastName = "Tolkien",
                    DOB = new DateTime(1892, 1, 03)
                },
                Genre = genre.Fantasy,
                Title = "Return of the King",
                NumberOfPages = 350,
            };
            library.Add(book3);
        }
    }
}
