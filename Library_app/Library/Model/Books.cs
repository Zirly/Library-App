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
        public static int LastIndex { get; set; }
        public static bool IsChanged { get; set; } = false;
        public static bool IsUpdated { get; set; } = false;

        // tämä pois?
        static Books()
        {
            Books.BooksList = new List<Book>();
            Books.LastIndex = GetLastIndex() + 1;

        }

        private static int GetLastIndex()
        {
            int id = 0;
            foreach (var item in BooksList)
            {
                if (item.BookId > id) id = item.BookId;
            }
            return id;
        }

        public static void AddBook(Book book)
        {
            book.BookId = LastIndex;
            LastIndex++;
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
        public static Book GetBook(string name)
        {
            Book book = new Book();
            foreach (var item in BooksList)
            {
                if (item.Title.ToLower() == name.ToLower()) book = item;
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
        public static bool RemoveBookByTitle(string name)
        {
            foreach (var book in BooksList)
            {
                if (book.Title == name)
                {
                    BooksList.Remove(book);
                    return true;
                }
            }
            return false;
        }

    }
}
