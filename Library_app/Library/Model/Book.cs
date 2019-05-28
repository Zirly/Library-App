using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public object Description { get; set; }
        public int? YearPublish { get; set; }
        public string Isbn { get; set; }
        public Genre Genre_AtBook { get; set; }
        public List<Author> AuthorsList { get; set; }

        public Book() { }

        public Book(int id, string title, string description, int year, string isbn, int genreId)
        {
            BookId = id;
            Title = title;
            Description = description;
            YearPublish = year;
            Isbn = isbn;
            AttachGenre(genreId);
            AuthorsList = new List<Author>();
        }

        public void AttachGenre(int id)
        {
            foreach (var item in Genres.GenresList)
            {
                if (item.GenreId == id)
                {
                    Genre_AtBook = item;
                }
            }
        }
    }
}
