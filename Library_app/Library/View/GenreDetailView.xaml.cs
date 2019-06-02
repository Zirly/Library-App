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
        // ?
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lstBooks.Items.Refresh();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            Genre genre = Genres.GetGenre(name);
            if (genre.BooksList.Count > 0) MessageBox.Show("Genre cannot be removed. The associated books must be removed first.");
            else if (MessageBox.Show("Are you sure you want to remove the genre?", "Remove genre", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Genres.RemoveGenre(genre);
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

        private void TxtName_GotFocus(object sender, RoutedEventArgs e)
        {
            GenreDetailViewModel viewmodel = (GenreDetailViewModel)DataContext;
            Genre genre = viewmodel.MyGenre;
            genre.IsUpdated = true;
            Genres.IsUpdated = true;
        }
    }
}
