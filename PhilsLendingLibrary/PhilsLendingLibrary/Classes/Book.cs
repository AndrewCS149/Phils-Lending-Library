﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Text;
using System.Threading;
using PhilsLendingLibrary.Classes;
using static PhilsLendingLibrary.Program;


namespace PhilsLendingLibrary.Classes
{
    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int NumberOfPages { get; set; }
        public genre Genre { get; set; }
        public enum genre : byte
        {
            Crime = 1,
            Drama,
            Fantasy,
            Horror,
            Mystery,
            Romance,
            SciFi,
            Western,
            Fiction,
            NonFiction,
            SelfCare
        }

        /// <summary>
        /// Retrieve the book details to add to the book bag
        /// </summary>
        /// <param name="library">Library to pull from</param>
        /// <param name="bookBag">Book bag to add to</param>
        public static void GetBookBagDetails(Library<Book> library, List<Book> bookBag)
        {
            // if library is empty
            if (library.Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("The library is empty.");
                Thread.Sleep(2500);
                Console.Clear();
            }
            // if library is not empty
            else
            {
                ViewBooks(library);
                Console.Write("Enter the title of the book you would like to borrow: ");
                string title = Console.ReadLine();
                Borrow(title, library, bookBag);
            }
        }

        /// <summary>
        /// Retrieve the book details from the user
        /// </summary>
        /// <param name="library">The library to add the book to</param>
        public static void GetBookDetails(Library<Book> library)
        {
            Console.Clear();
            Console.Write("Enter the title: ");
            string title = Console.ReadLine();

            Console.Write("Enter the author's first name: ");
            string first = Console.ReadLine();

            Console.Write("Enter the author's first name: ");
            string last = Console.ReadLine();

            Console.Write("Enter the number of pages: ");
            string pageInput = Console.ReadLine();

            int pages;
            bool validInput = Int32.TryParse(pageInput, out pages);
            // validate page input
            while (!validInput || pages <= 0)
            {
                Console.WriteLine("Invalid input");
                Console.Write("Enter the number of pages: ");
                pageInput = Console.ReadLine();
                validInput = Int32.TryParse(pageInput, out pages);
            }

            Console.WriteLine("Select Genre: ");
            DisplayGenres();

            // get genre selection from user
            string selection = Console.ReadLine();
            int result;
            bool validGenre = Int32.TryParse(selection, out result);

            // validation genre selection
            while (!validGenre || (result < 1 || result > 11))
            {
                Console.Clear();
                Console.WriteLine("Invalid selection.");
                Console.WriteLine();
                Console.WriteLine("Select Genre: ");
                DisplayGenres();
                selection = Console.ReadLine();
                validGenre = Int32.TryParse(selection, out result);
            }

            // genre choice result
            genre genreChoice = GenreSelection(result);

            // library
            AddABook(title, first, last, pages, library, genreChoice);
            Console.Clear();
        }

        /// <summary>
        /// Controls which genre choice is selected
        /// </summary>
        /// <param name="choice">The user choice</param>
        /// <returns>The selected genre</returns>
        public static genre GenreSelection(int choice)
        {
            switch (choice)
            {
                case 1:
                    return genre.Crime;
                case 2:
                    return genre.Drama;
                case 3:
                    return genre.Fantasy;
                case 4:
                    return genre.Horror;
                case 5:
                    return genre.Mystery;
                case 6:
                    return genre.Romance;
                case 7:
                    return genre.SciFi;
                case 8:
                    return genre.Western;
                case 9:
                    return genre.Fiction;
                case 10:
                    return genre.NonFiction;
                case 11:
                    return genre.SelfCare;
            }

            // this cannot be reached, it is here to full fill all code paths returning a value
            return genre.Crime;
        }

        /// <summary>
        /// Displays a selection of genres
        /// </summary>
        private static void DisplayGenres()
        {
            int count = 1;
            foreach (var i in Enum.GetValues(typeof(genre)))
            {
                Console.WriteLine($"{count}: {i}");
                count++;
            }
        }

        /// <summary>
        /// Adds a book to the users current library
        /// </summary>
        /// <param name="title">Title of book</param>
        /// <param name="firstName">First name of author</param>
        /// <param name="lastName">Last name of author</param>
        /// <param name="numberOfPages">Number of pages</param>
        /// <param name="library">Library to add book to</param>
        public static void AddABook(string title, string firstName, string lastName, int numberOfPages, Library<Book> library, genre genre)
        {
            // create new book instance and fill out properties
            Book book = new Book()
            {
                Title = title,
                Author = new Author()
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                NumberOfPages = numberOfPages,
                Genre = genre
            };
            // add to library
            library.Add(book);
        }

        /// <summary>
        /// Removes a book from the library
        /// </summary>
        /// <param name="library">The library to check</param>
        public static void RemoveBook(Library<Book> library)
        {
            // if library is empty
            if (library.Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("Library is empty");
                Thread.Sleep(2500);
            }
            // if library is not empty
            else
            {
                ViewBooks(library);
                Console.Write("Enter the title of the book you would like to remove: ");
                string removedBook = Console.ReadLine();

                // loop through library to see if input matches an existing book
                foreach (Book book in library)
                {
                    if (book.Title.ToLower() == removedBook.ToLower())
                    {
                        library.Remove(book);
                        Console.Clear();
                        return;
                    }
 
                }
            }
            Console.Clear();
            Console.WriteLine("That book isn't in our library: Redirecting to home...");
            Thread.Sleep(2500);
            Console.Clear();
        }

        /// <summary>
        /// Displays all books inside of library
        /// </summary>
        /// <param name="bookBag">Library to display books from</ param>
        public static void ViewBooks(Library<Book> library)
        {
            // if library is empty
            if (library.Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("The library is empty.");
                Thread.Sleep(2500);
                Console.Clear();
            }
            // if library is not empty
            else
            {
                int count = 1;
                foreach (Book book in library)
                {
                    Console.WriteLine($"{count++}) {book.Title} - {book.Genre} - {book.Author.FirstName} {book.Author.LastName}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Moves a book from the book bag to the library
        /// </summary>
        /// <param name="library">Library to return book to</param>
        /// <param name="bookBag">Book bag to remove from</param>
        public static void ReturnBook(Library<Book> library, List<Book> bookBag)
        {
            // If book bag is empty
            if (bookBag.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Your book bag is empty.");
                Thread.Sleep(2500);
                Console.Clear();
            }
            // if book bag is not empty
            else
            {
                // create key value pair dict
                Dictionary<int, Book> books = new Dictionary<int, Book>();
                Console.WriteLine("Which book would you like to return:");
                int counter = 1;

                // display all items in book bag
                foreach (var item in bookBag)
                {
                    books.Add(counter, item);
                    Console.WriteLine($"{counter++}. {item.Title} - {item.Genre} - {item.Author.FirstName} {item.Author.LastName}");
                }

                // store user choice
                string response = Console.ReadLine();
                int.TryParse(response, out int selection);
                bool inBag = books.TryGetValue(selection, out Book returnedBook);

                // while user chooses an invalid option
                while (!inBag)
                {
                    Console.WriteLine("Invalid selection");
                    Console.WriteLine("Which book would you like to return");
                    response = Console.ReadLine();
                    int.TryParse(response, out selection);
                    inBag = books.TryGetValue(selection, out returnedBook);
                }

                // Use library Remove() to remove the book from the book bag
                bookBag.Remove(returnedBook);
                // Add the book back to library
                library.Add(returnedBook);
                Console.Clear();
            }

        }
    }
}

