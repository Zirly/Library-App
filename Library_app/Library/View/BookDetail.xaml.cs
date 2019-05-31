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

        private void Item_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove item?", "Remove Item", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                BookDetailViewModel sd = (BookDetailViewModel)DataContext;
                Book book = sd.MyBook;
                Books.RemoveBook(sd.MyBook.BookId);
      
                var mw = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(window => window is MainWindow) as MainWindow;

                mw.DataContext = new
                {
                    collection = new BooksListViewModel(),
                    detail = new BookDetailViewModel(Books.GetBook(Books.BooksList.Count))
                };
            }
            else
            {
            }
        }
    }
}
