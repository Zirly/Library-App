using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public static class Genres
    {
        public static List<Genre> GenresList { get; set; }
        public static int Count { get; set; }

        // tämä pois?
        static Genres()
        {
            Genres.GenresList = new List<Genre>();
            Genres.Count = 0;

        }

        //TODO id
        public static void AddGenre(Genre genre)
        {
            GenresList.Add(genre);
            Count++;
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

    }
}
