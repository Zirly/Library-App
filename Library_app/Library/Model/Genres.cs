using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public static class Genres
    {
        public static bool IsChanged { get; set; } = false; 
        public static List<Genre> GenresList { get; set; }
        public static int LastIndex { get; set; }

     
        static Genres()
        {
            Genres.GenresList = new List<Genre>();
            Genres.LastIndex = GetLastIndex() + 1;
            
        }

        private static int GetLastIndex()
        {
            int id = 0;
            foreach (var item in GenresList)
            {
                if (item.GenreId > id) id = item.GenreId;
            }
            return id;
        }

     
        public static void AddGenre(Genre genre)
        {
            genre.GenreId = LastIndex;
            LastIndex++;
            GenresList.Add(genre);
        }

        public static void AddBookToGenre(Book book, Genre genre)
        {
            foreach (var g in GenresList)
            {
                if ( g == genre)
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
        public static Genre GetGenre(string name)
        {
            Genre genre = new Genre();
            foreach (var item in GenresList)
            {
                if (item.Name.ToLower() == name.ToLower()) genre = item;
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
        public static bool RemoveGenre(Genre genre)
        {
            foreach (var item in GenresList)
            {
                if (item == genre)
                {
                    GenresList.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
