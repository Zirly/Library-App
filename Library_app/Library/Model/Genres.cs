using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    /// <summary>
    /// Static class that holds all the genres together
    /// </summary>
    public static class Genres
    {
        //properties
        public static bool AreRemovedItems { get; set; } = false;
        public static bool IsUpdated { get; set; } = false;
        public static List<Genre> GenresList { get; set; }
 
        //constructor
        static Genres()
        {
            Genres.GenresList = new List<Genre>();         
        }
        //methods
        /// <summary>
        /// Adding genre to the list
        /// </summary>
        /// <param name="genre">genre's id</param>
        public static void AddGenre(Genre genre)
        {
            GenresList.Add(genre);
        }
        /// <summary>
        /// Connecting book to a genre
        /// </summary>
        /// <param name="book">book to add</param>
        /// <param name="genre">genre to get a book</param>
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
        /// <summary>
        /// Finding genre from the list
        /// </summary>
        /// <param name="id">genre's id</param>
        /// <returns>Found genre</returns>
        public static Genre GetGenre(int id)
        {
            Genre genre = new Genre();
            foreach (var item in GenresList)
            {
                if (item.GenreId == id) genre = item;
            }
            return genre;
        }
        /// <summary>
        /// Removing genre from the list
        /// </summary>
        /// <param name="id">genre's id</param>
        /// <returns>true, if genre is removed, otherwise false</returns>
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
