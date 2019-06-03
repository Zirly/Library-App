using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    /// <summary>
    /// Static class that holds together all the books
    /// </summary>
    public static class Books
    {
        // properties
        public static bool AreRemovedItems { get; set; } = false;
        public static List<Book> BooksList { get; set; }
        public static bool IsUpdated { get; set; } = false;

        //constructor
        static Books()
        {
            Books.BooksList = new List<Book>();
        }

        //methods
        /// <summary>
        /// Adding book to the list
        /// </summary>
        /// <param name="book">Book to add</param>
        public static void AddBook(Book book)
        {
            BooksList.Add(book);
        }

        /// <summary>
        /// Finding book from the list
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>Found book</returns>
        public static Book GetBook(int id)
        {
            Book book = new Book();
            foreach (var item in BooksList)
            {
                if (item.BookId == id) book = item;
            }
            return book;
        }

        /// <summary>
        /// Removing book from the list
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>true if book is removed, otherwise false</returns>
        public static bool RemoveBook(int id)
        {
            foreach (var book in BooksList)
            {
                if (book.BookId == id)
                {
                    BooksList.Remove(book);
                    return true;
                }
            }
            return false;
        }
    }
}
