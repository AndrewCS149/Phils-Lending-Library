using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using PhilsLendingLibrary.Classes;

namespace PhilsLendingLibrary.Classes
{
    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int NumberOfPages { get; set; }
        public enum Genre : byte
        {
            //Crime,
            //Drama,
            //Fantasy,
            //Horror,
            //Mystery,
            //Romance,
            //SciFi,
            //Western,
            //Fiction,
            //NonFiction,
            //SelfCare
        }

        //public int count = 0;

        //static void ReturnBook()
        //{
        //    Dictionary<int, Book> books = new Dictionary<int, Book>();
        //    Console.WriteLine("Which book would you like to return");
        //    int counter = 1;
        //    foreach (var item in BookBag)
        //    {
        //        books.Add(counter, item);
        //        Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

        //    }
        //    string response = Console.ReadLine();
        //    int.TryParse(response, out int selection);
        //    books.TryGetValue(selection, out Book returnedBook);
        //    BookBag.Remove(returnedBook);
        //    Library.Add(returnedBook);
        //}

        //static void AddABook(string title, string firstName, string lastName, int numberOfPages, Genre genre)
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
        //        Genre = (genre)0;
        //};

        //Library.Add(book);
    }
}

