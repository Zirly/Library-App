using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public List<Book> BooksList { get; set; }

        public Genre() { }
        public Genre(int id, string name)
        {
            GenreId = id;
            Name = name;
            BooksList = new List<Book>();
        }

        public void AddBook(Book book)
        {
            BooksList.Add(book);
        }
    }
}
