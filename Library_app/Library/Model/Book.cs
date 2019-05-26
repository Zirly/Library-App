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
        public int GenreId { get; set; }
    }
}
