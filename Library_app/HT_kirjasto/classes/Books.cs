using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_kirjasto.classes
{
    public class Books
    {
        public List<Book> BooksList { get; set; }
        public int Count { get; set; }

        //TODO id
        public void AddBook(Book book)
        {
            BooksList.Add(book);
            Count++;
        }

        public Book GetBook(int id)
        {
            Book book = new Book();
            foreach (var item in BooksList)
            {
                if (item.BookId == id) book = item;
            }
            return book;
        }
        public Book GetBook(string name)
        {
            Book book = new Book();
            foreach (var item in BooksList)
            {
                if (item.Title.ToLower() == name.ToLower()) book = item;
            }
            return book;
        }

        //TODO poista myös relation
        public bool RemoveBook(int id)
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
