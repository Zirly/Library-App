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

            BooksListControl.lstBooks.ItemsSource = Books.BooksList;

            BooksListControl.lstBooks.SelectedIndex = 0;


            Author authorTest = Authors.GetAuthor(1);
            AuthorDetailControl.authorDetailData.DataContext = authorTest;

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            BooksListControl.lstBooks.ItemsSource = Books.BooksList;
            BooksListControl.lstBooks.Items.Refresh();
            BooksListControl.lstBooks.SelectedIndex = 0;
        }
    }
}
