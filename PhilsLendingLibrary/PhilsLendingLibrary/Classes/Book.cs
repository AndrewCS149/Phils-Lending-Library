using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PhilsLendingLibrary.Classes
{
    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int NumberOfPages { get; set; }
        public enum Genre : byte
        {
            Crime,
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
    }
}
