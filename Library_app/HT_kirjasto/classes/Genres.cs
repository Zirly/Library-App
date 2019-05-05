using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_kirjasto.classes
{
    public class Genres
    {
        public List<Genre> GenresList { get; set; }
        public int Count { get; set; }

        //TODO id
        public void AddGenre(Genre genre)
        {
            GenresList.Add(genre);
            Count++;
        }

        public Genre GetGenre(int id)
        {
            Genre genre = new Genre();
            foreach (var item in GenresList)
            {
                if (item.GenreId == id) genre = item;
            }
            return genre;
        }
        public Genre GetGenre(string name)
        {
            Genre genre = new Genre();
            foreach (var item in GenresList)
            {
                if (item.Name.ToLower() == name.ToLower()) genre = item;
            }
            return genre;
        }

        //TODO poista myös relation
        public bool RemoveGenre(int id)
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
