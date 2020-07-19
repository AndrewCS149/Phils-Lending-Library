using System;
using Xunit;
using PhilsLendingLibrary.Classes;
using static PhilsLendingLibrary.Classes.Book;
using static PhilsLendingLibrary.Classes.UserInterface;
using static PhilsLendingLibrary.Program;
using System.Collections.Generic;

namespace PhilsLibraryTests
{
    public class UnitTest1
    {
        // Test AddABook()
        [Fact]
        public void CanAddBookToLibrary()
        {
            // arrange
            Library<Book> library = new Library<Book>();

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

            // act
            bool inLibrary = library.InLibrary(book1);

            // assert
            Assert.True(inLibrary);
        }

        // Test Count()
        [Fact]
        public void CanReturnNumberOfBooksInLibrary()
        {
            // arrange
            Library<Book> library = new Library<Book>();

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

            library.Add(book1);
            library.Add(book2);

            // act 
            int actual = library.Count();
            int expected = 2;

            // assert
            Assert.Equal(expected, actual);
        }

        // Test Remove()
        [Fact]
        public void CanRemoveLibraryFromBook()
        {
            // arrange
            Library<Book> library = new Library<Book>();

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

            // act & assert
            Assert.False(library.InLibrary(book1));
        }

        // Test Book class properties
        [Fact]
        public void CanGetAndSetBookProperties()
        {
            // arrange
            Book book = new Book();
            book.Title = "IT";
            book.NumberOfPages = 200;
            book.Genre = genre.Crime;

            // act
            bool canGetProperties;
            if (book.Title == "IT" && book.NumberOfPages == 200 && book.Genre == genre.Crime)
                canGetProperties = true;
            else
                canGetProperties = false;

            // assert
            Assert.True(canGetProperties);
        }

        // Test Author class properties
        [Fact]
        public void CanGetAndSetAuthorProperties()
        {
            // arrange
            Author author = new Author();
            author.FirstName = "Stephen";
            author.LastName = "King";
            author.DOB = new DateTime(1947, 09, 21);

            // act
            bool canGetProperties;
            if (author.FirstName == "Stephen" && author.LastName == "King" && author.DOB == new DateTime(1947, 09, 21))
                canGetProperties = true;
            else
                canGetProperties = false;

            // assert
            Assert.True(canGetProperties);
        }

        // Test LoadBooks()
        [Fact]
        public void CanLoadBooksIntoLibraryWithLoadBooksMethod()
        {
            // arrange
            Library<Book> library = new Library<Book>();

            // act
            LoadBooks(library);
            int booksInLibrary = library.Count();

            // assert
            Assert.Equal(3, booksInLibrary);
        }
    }
}
