using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public static class Books
    {
        public static bool AreRemovedItems { get; set; } = false;
        public static List<Book> BooksList { get; set; }
        public static bool IsUpdated { get; set; } = false;

        static Books()
        {
            Books.BooksList = new List<Book>();
        }

        public static void AddBook(Book book)
        {
            BooksList.Add(book);
        }

        public static Book GetBook(int id)
        {
            Book book = new Book();
            foreach (var item in BooksList)
            {
                if (item.BookId == id) book = item;
            }
            return book;
        }

        //TODO poista myös relation
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
