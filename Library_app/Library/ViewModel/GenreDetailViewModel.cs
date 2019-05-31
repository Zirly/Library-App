using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.ViewModel
{
    public class GenreDetailViewModel
    {
        public Genre MyGenre { get; set; }

        public GenreDetailViewModel(Genre genre)
        {
            MyGenre = genre;

        }
    }
}
