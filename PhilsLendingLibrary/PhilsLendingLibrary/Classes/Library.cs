using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PhilsLendingLibrary.Classes
{
    public class Library<T> : IEnumerable<T>
    {
        T[] items = new T[5];
        int count;

        /// <summary>
        /// Adds more space to the list if necessary 
        /// </summary>
        /// <param name="item">The list to add space to</param>
        public void Add(T item)
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

        /// <summary>
        /// Removes a book from the library
        /// </summary>
        /// <param name="idx">Index of the book to remove</param>
        //public void Remove(int idx)
        //{
        //    T[] temp;
        //    if(count < (items.Length / 2))
        //        temp = new T[count - 1];
        //    else
        //        temp = new T[items.Length];
        //    items = temp;
        //}

        public IEnumerator<T> GetEnumerator()
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
