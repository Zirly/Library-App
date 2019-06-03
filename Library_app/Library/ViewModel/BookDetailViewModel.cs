using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.ViewModel
{
    /// <summary>
    /// Interaction logic for BookDetailView.xaml
    /// </summary>
    public class BookDetailViewModel
    {
        public Book MyBook { get; set; }

        public BookDetailViewModel(Book book)
        {
            MyBook = book;

        }
        public BookDetailViewModel() { }
    }
}
