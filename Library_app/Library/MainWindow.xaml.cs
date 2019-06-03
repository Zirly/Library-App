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
    /*
    * author: Markéta Sovová, M1482@student.jamk.fi
    * author: Arttu Rousku, M1484@student.jamk.fi
    * time: 31/5/2019 18:22 PM
    * 
    * Library program provides a tool to store library data, which include books and their
    * associated authors and genres. Application enables data addition, removal and update.
    */

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                MSAConnectionDB.LoadData();
                DataContext = new
                {
                    collection = new BooksListViewModel(),
                    detail = new BookDetailViewModel()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Showing book's views - collection and detail
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void BooksSelection_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new
            {
                collection = new BooksListViewModel(),      
                detail = new BookDetailViewModel()       
            }; 
        }
        /// <summary>
        /// Showing autho's views - collection and detail
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void AuthorsSelection_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new
            {
                collection = new AuthorsListViewModel(),
                detail = new AuthorDetailViewModel()
            };

        }
        /// <summary>
        /// Showing genre's views - collection and detail
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void GenresSelection_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new
            {
                collection = new GenresListViewModel(),
                detail = new GenreDetailViewModel()
            };
        }

        /// <summary>
        /// Opening window for adding item
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void Item_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            ItemAdd itemAdd = new ItemAdd();
            itemAdd.Show();
        }

        /// <summary>
        /// Main window loaded
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    DataContext = new
                    {
                        collection = new BooksListViewModel(),
                        detail = new BookDetailViewModel(Books.BooksList[0])
                    };
                    break;
                case 1:
                    DataContext = new
                    {
                        collection = new AuthorsListViewModel(),
                        detail = new AuthorDetailViewModel(Authors.AuthorsList[0])
                    };
                    break;
                case 2:
                    DataContext = new
                    {
                        collection = new GenresListViewModel(),
                        detail = new GenreDetailViewModel(Genres.GenresList[0])
                    };
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Exit button logic
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (LibraryModel.AreItemsRemoved() || LibraryModel.AreItemsUpdated())
            {
                if (MessageBox.Show("All unsaved changes will be lost. Are you sure you want to exit?", "Exit Program", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    LibraryModel.ChangesSaved();
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// Save button - sending data to be save to DB
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MSAConnectionDB.SaveDataToDB()) MessageBox.Show("Changes saved");
            else MessageBox.Show("No changes");                    
        }

        /// <summary>
        /// Closing window logic
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (LibraryModel.AreItemsRemoved() || LibraryModel.AreItemsUpdated())
            {
                if (MessageBox.Show("All unsaved changes will be lost. Are you sure you want to exit?", "Exit Program", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }          
            }
        }
    }
}
