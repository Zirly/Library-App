using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.Model;
using Library.ViewModel;

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DatabaseConnection.ReadDataFromDB();

            //BooksListControl.lstBooks.ItemsSource = Books.BooksList;

            //BooksListControl.lstBooks.SelectedIndex = 0;


        }

        private void BooksSelection_Selected(object sender, RoutedEventArgs e)
        {
            
           
            DataContext = new
            {
                collection = new BooksListViewModel(),
                detail = new BookDetailViewModel()
            };
        }

        private void AuthorsSelection_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new
            {
                collection = new AuthorsListViewModel(),
                detail = new AuthorDetailViewModel()
            };
        }

        private void GenresSelection_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new
            {
                collection = new GenresListViewModel(),
                detail = new GenreDetailViewModel()
            };
        }
        /*
private void Window_Activated(object sender, EventArgs e)
{
BooksListControl.lstBooks.ItemsSource = Books.BooksList;
BooksListControl.lstBooks.Items.Refresh();
BooksListControl.lstBooks.SelectedIndex = 0;
} */
    }
}
