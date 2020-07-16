using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.Write("Enter the title: ");
            string title = Console.ReadLine();
            Borrow(title, library, bookBag);
        }

        /// <summary>
        /// Retrieve the book details from the user
        /// </summary>
        /// <param name="library">The library to add the book to</param>
        public static void GetBookDetails(Library<Book> library)
        {
            Console.Write("Enter the title: ");
            string title = Console.ReadLine();
            Console.Write("Enter the author's first name: ");
            string first = Console.ReadLine();
            Console.Write("Enter the author's first name: ");
            string last = Console.ReadLine();
            Console.Write("Enter the number of pages: ");
            int pages = int.Parse(Console.ReadLine());
            Console.WriteLine("Select Genre: ");
            DisplayGenres();

            // get genre selection from user
            string selection = Console.ReadLine();
            int result;
            if(Int32.TryParse(selection, out result))
            {
                if (result < 1 || result > 11)
                {
                    Console.WriteLine("Invalid selection");
                    Console.WriteLine("Select Genre: ");
                    DisplayGenres();
                }
            } else
            {
                Console.WriteLine("Invalid selection");
                Console.WriteLine("Select Genre: ");
                DisplayGenres();
            }
            genre genreChoice = GenreSelection(result);
            AddABook(title, first, last, pages, library, genreChoice);
        }

        /// <summary>
        /// Controls which genre choice is selected
        /// </summary>
        /// <param name="choice">The user choice</param>
        /// <returns>The selected genre</returns>
        public static genre GenreSelection(int choice)
        {
            switch(choice)
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

            library.Add(book);
        }


        /// <summary>
        /// Displays all books inside of book bag
        /// </summary>
        /// <param name="bookBag">Book bag to display books from</ param>
        public static void ViewBooks(Library<Book> library)
        {
            foreach (Book book in library)
            {
                Console.Write($"{book.Title} - {book.Genre} - {book.Author.FirstName} {book.Author.LastName}");
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
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to return");
            int counter = 1;
            foreach (var item in bookBag)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            bookBag.Remove(returnedBook);
            library.Add(returnedBook);
        }
    }
}

