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
        /// <param name="item">Index of the book to remove</param>
        /// <returns>The removed book</returns>
        public T Remove(T item)
        {
            T[] temp;
            int tempCount = 0;
            T removed = default(T);

            if (InLibrary(item))
            {
                // to prevent idx out of range errors, keep minimum size to 2
                if (count <= 2)
                {
                    temp = new T[2];
                }
                else if (count < (items.Length / 2))
                    temp = new T[count - 1];
                else
                    temp = new T[items.Length];

                for (int i = 0; i < count; i++)
                {
                    if (items[i] != null)
                    {
                        if (!items[i].Equals(item))
                        {
                            temp[tempCount] = items[i];
                            tempCount++;
                        }
                        else
                            removed = items[i];
                    }
                }

                items = temp;
                count--;
            }
            return removed;
        }

        /// <summary>
        /// Checks to see if book is currently in library
        /// </summary>
        /// <param name="book">Book to check for</param>
        /// <returns>True if book is found, false if not</returns>
        public bool InLibrary(T book)
        {
            try
            {
                foreach (T item in items)
                {
                    if (item.Equals(book) && item != null)
                        return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

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
