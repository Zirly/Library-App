using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library.Model;
using Library.ViewModel;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for BookDetail.xaml
    /// </summary>
    public partial class BookDetail : UserControl
    {
        public BookDetail()
        {
            InitializeComponent();
        }

        private void BookRemove_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove the book?", "Remove Book", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                string title = txtBookTitle.Text;
                Book book = Books.GetBook(title);
                foreach (Author author in Authors.AuthorsList)
                {
                    if (author.BooksList.Contains(book)) author.BooksList.Remove(book);
                }
                foreach (Genre genre in Genres.GenresList)
                {
                    if (genre.BooksList.Contains(book)) genre.BooksList.Remove(book);
                }
                Books.RemoveBookByTitle(title);
                var mw = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(window => window is MainWindow) as MainWindow;

                mw.DataContext = new
                {
                    collection = new BooksListViewModel(),
                    detail = new BookDetailViewModel(Books.GetBook(Books.BooksList.Count))
                };
            }
        }
    }
}
