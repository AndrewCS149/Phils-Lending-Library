using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PhilsLendingLibrary.Classes
{
    public class Library<Book> : IEnumerable<Book>
    {
        Book[] items = new Book[5];
        int count;

        public void Add(Book item)
        {
            // evaluate the length of items vs the count
            if (count == items.Length)
            {
                // resize the array to allow for more data
                Array.Resize(ref items, items.Length * 2);
            }
            items[count++] = item;
        }

        public int Count()
        {
            return count;
        }

        public void Remove(string title)
        {

        }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
