using System;
using System.Collections.Generic;
using System.Text;

namespace PhilsLendingLibrary.Classes
{
    public class UserInterface
    {
        /// <summary>
        /// Displays the menu to the user
        /// </summary>
        public static void DisplayMenu(Library<Book> library)
        {
            Menu();
            string option = Console.ReadLine();
            Selection(option, library);

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
        private static void Selection(string option, Library<Book> library)
        {
            switch (option)
            {
                case "1":
                    ViewBooks(library);
                    break;
                case "2":
                    Console.WriteLine("Add book");
                    break;
                case "3":
                    Console.WriteLine("Borrow");
                    break;
                case "4":
                    Console.WriteLine("Return");
                    break;
                case "5":
                    Console.WriteLine("View book bag");
                    break;
                case "6":
                    Console.WriteLine("Exit");
                    break;
            }
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
