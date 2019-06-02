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
using Library.View;
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
            MSAConnectionDB.MakeConnection();
            //DatabaseConnection.ReadDataFromDB();
            DataContext = new
            {
                collection = new BooksListViewModel(),
                detail = new BookDetailViewModel(Books.GetBook(1))
            };
            
        }

        private void BooksSelection_Selected(object sender, RoutedEventArgs e)
        {
            
            DataContext = new
            {
                collection = new BooksListViewModel(),      
                detail = new BookDetailViewModel(Books.GetBook(1))       
            }; 
        }

        private void AuthorsSelection_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new
            {
                collection = new AuthorsListViewModel(),
                detail = new AuthorDetailViewModel(Authors.GetAuthor(1))
            };

        }

        private void GenresSelection_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new
            {
                collection = new GenresListViewModel(),
                detail = new GenreDetailViewModel(Genres.GetGenre(1))
            };
        }

        private void Item_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            ItemAdd itemAdd = new ItemAdd();
            itemAdd.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    DataContext = new
                    {
                        collection = new BooksListViewModel(),
                        detail = new BookDetailViewModel(Books.GetBook(Books.BooksList.Count))
                    };
                    break;
                case 1:
                    DataContext = new
                    {
                        collection = new AuthorsListViewModel(),
                        detail = new AuthorDetailViewModel(Authors.GetAuthor(Authors.AuthorsList.Count))
                    };
                    break;
                case 2:
                    DataContext = new
                    {
                        collection = new GenresListViewModel(),
                        detail = new GenreDetailViewModel(Genres.GetGenre(Genres.GenresList.Count))
                    };
                    break;
                default:
                    break;
            }
        }
        
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Program", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();
            }
            else
	        {
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            // DatabaseConnection.SaveDataToDB();
            if (MSAConnectionDB.SaveDataToDB()) MessageBox.Show("Changes saved");
            else MessageBox.Show("No changes");
        }
    }
}
