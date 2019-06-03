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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.Model;
using Library.ViewModel;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for GenreDetailView.xaml
    /// </summary>
    public partial class GenreDetailView : UserControl
    {
        public GenreDetailView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Removing genre from the static list on button click
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Genres.GenresList.Count < 1)
            {
                MessageBox.Show("No genres to remove.");
                return;
            }
            GenreDetailViewModel viewmodel = (GenreDetailViewModel)DataContext;
            Genre genre = Genres.GetGenre(viewmodel.MyGenre.GenreId); 
            if (genre.BooksList.Count > 0) MessageBox.Show("Genre cannot be removed. The associated books must be removed first.");
            else if (MessageBox.Show("Are you sure you want to remove the genre?", "Remove genre", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Genres.RemoveGenre(genre.GenreId);
                Genres.AreRemovedItems = true;
                var mw = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(window => window is MainWindow) as MainWindow;

                mw.DataContext = new
                {
                    collection = new GenresListViewModel(),
                    detail = new GenreDetailViewModel(Genres.GetGenre(Genres.GenresList.Count))
                };
            }
        }

        /// <summary>
        /// Setting genre to be updated, if user has clicked the input field
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void TxtName_GotFocus(object sender, RoutedEventArgs e)
        {
            GenreDetailViewModel viewmodel = (GenreDetailViewModel)DataContext;
            Genre genre = viewmodel.MyGenre;
            genre.IsUpdated = true;
            Genres.IsUpdated = true;
        }

        /// <summary>
        /// Checking that the genre's name is not empty and that it doesn't already exist
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void TxtName_LostFocus(object sender, RoutedEventArgs e)
        {
            GenreDetailViewModel viewmodel = (GenreDetailViewModel)DataContext;
            Genre oldGenre = viewmodel.MyGenre;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Field cannot be empty!");
                txtName.Text = oldGenre.Name;
            }

            foreach (var genre in Genres.GenresList)
            {
                if (genre.Name == txtName.Text && (oldGenre.GenreId != genre.GenreId))
                {
                    MessageBox.Show("Genre already exists!");
                    
                    txtName.Text = oldGenre.Name;
                    break;
                }
            }
        }
    }
}
