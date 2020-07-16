using System;
using System.Collections.Generic;
using System.Text;
using static PhilsLendingLibrary.Program;

namespace PhilsLendingLibrary.Classes
{
    public class UserInterface
    {
        /// <summary>
        /// Displays the menu to the user
        /// </summary>
        public static void DisplayMenu(Library<Book> library, List<Book> bookBag)
        {
            string option = "";
            while (option != "6")
            {
                Menu();
                option = Console.ReadLine();
                Selection(option, library, bookBag);
            }

            Console.WriteLine("Thank you for using Phil's Lending Library!");
        }

        /// <summary>
        /// Proved the menu data to the DisplayMenu() method
        /// </summary>
        private static void Menu()
        {
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("1) View all Books");
            Console.WriteLine("2) Add a Book");
            Console.WriteLine("3) Borrow a book");
            Console.WriteLine("4) Return a book");
            Console.WriteLine("5) View Book Bag");
            Console.WriteLine("6) Exit");
        }

        /// <summary>
        /// Navigates user to appropriate methods based on their selection
        /// </summary>
        /// <param name="option">The option selected</param>
        private static void Selection(string option, Library<Book> library, List<Book> bookBag)
        {
            Console.Clear();
            switch (option)
            {
                case "1":
                    ViewBooks(library);
                    break;
                case "2":
                    GetBookDetails(library);
                    Console.WriteLine("Add book");
                    break;
                case "3":
                    GetBookBagDetails(library, bookBag);
                    break;
                case "4":
                    Console.WriteLine("Return");
                    break;
                case "5":
                    ViewBookBag(bookBag);
                    break;
            }
        }
        
        /// <summary>
        /// Retrieve the book details to add to the book bag
        /// </summary>
        /// <param name="library">Library to pull from</param>
        /// <param name="bookBag">Book bag to add to</param>
        private static void GetBookBagDetails(Library<Book> library, List<Book> bookBag)
        {
            Console.Write("Enter the title: ");
            string title = Console.ReadLine();
            Borrow(title, library, bookBag);
        }

        /// <summary>
        /// Retrieve the book details from the user
        /// </summary>
        /// <param name="library">The library to add the book to</param>
        private static void GetBookDetails(Library<Book> library)
        {
            Console.Write("Enter the title: ");
            string title = Console.ReadLine();
            Console.Write("Enter the author's first name: ");
            string first = Console.ReadLine();
            Console.Write("Enter the author's first name: ");
            string last = Console.ReadLine();
            Console.Write("Enter the number of pages: ");
            int pages = int.Parse(Console.ReadLine());

            AddABook(title, first, last, pages, library);
        }

        /// <summary>
        /// Adds a book to the users current library
        /// </summary>
        /// <param name="title">Title of book</param>
        /// <param name="firstName">First name of author</param>
        /// <param name="lastName">Last name of author</param>
        /// <param name="numberOfPages">Number of pages</param>
        /// <param name="library">Library to add book to</param>
        static void AddABook(string title, string firstName, string lastName, int numberOfPages, Library<Book> library)
        {
            Book book = new Book()
            {
                Title = title,
                Author = new Author()
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                NumberOfPages = numberOfPages,
                //Genre = genre
            };

            library.Add(book);
        }


        /// <summary>
        /// Displays all books inside of book bag
        /// </summary>
        /// <param name="bookBag">Book bag to display books from</ param>
        private static void ViewBooks(Library<Book> library)
        {
            foreach (Book book in library)
            {
                Console.Write($"{book.Title} - {book.Author.FirstName} {book.Author.LastName}");
                Console.WriteLine();
            }
        }
    }
}
