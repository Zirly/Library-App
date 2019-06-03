using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public static class Genres
    {
        public static bool AreRemovedItems { get; set; } = false;
        public static bool IsChanged { get; set; } = false;
        public static bool IsUpdated { get; set; } = false;
        public static List<Genre> GenresList { get; set; }
 
        static Genres()
        {
            Genres.GenresList = new List<Genre>();         
        }
   
        public static void AddGenre(Genre genre)
        {
            GenresList.Add(genre);
        }

        public static void AddBookToGenre(Book book, Genre genre)
        {
            foreach (var g in GenresList)
            {
                if ( g.GenreId == genre.GenreId)
                {
                    g.AddBook(book);
                }
            }
        }

        public static Genre GetGenre(int id)
        {
            Genre genre = new Genre();
            foreach (var item in GenresList)
            {
                if (item.GenreId == id) genre = item;
            }
            return genre;
        }

        //TODO poista myös relation
        public static bool RemoveGenre(int id)
        {
            foreach (var genre in GenresList)
            {
                if (genre.GenreId == id)
                {
                    GenresList.Remove(genre);
                    return true;
                }
            }
            return false;
        }
    }
}
