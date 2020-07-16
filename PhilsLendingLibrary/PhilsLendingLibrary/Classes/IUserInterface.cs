using System;
using System.Collections.Generic;
using System.Text;
using static PhilsLendingLibrary.Program;
using static PhilsLendingLibrary.Classes.Book;

namespace PhilsLendingLibrary.Classes
{
    public class UserInterface
    {
        /// <summary>
        /// Displays the menu to the user
        /// </summary>
        public static void StartApplication(Library<Book> library, List<Book> bookBag)
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
                    break;
                case "3":
                    GetBookBagDetails(library, bookBag);
                    break;
                case "4":
                    ReturnBook(library, bookBag);
                    break;
                case "5":
                    ViewBookBag(bookBag);
                    break;
            }
        }
    }
}
