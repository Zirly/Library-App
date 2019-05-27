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
            DatabaseConnection.ReadBooksFromDatabase();
            DatabaseConnection.ReadAuthorsFromDatabase();
            DatabaseConnection.ReadGenresFromDatabase();
            DatabaseConnection.ReadRelationsFromDatabase();

        }

        private void TestDB_Click(object sender, RoutedEventArgs e)
        {
            lstBooks.ItemsSource = Books.BooksList;
            lstAuthors.ItemsSource = Authors.AuthorsList;
            lstGenres.ItemsSource = Genres.GenresList;
            lstRelations.ItemsSource = Relations.RelationsList;
        }
    }
}
