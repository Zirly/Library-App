using Library.ViewModel.ItemAddViewModel;
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
using Library.View.ItemAddView;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for BookAdd.xaml
    /// </summary>
    public partial class ItemAdd : Window
    {
        public ItemAdd()
        {
            InitializeComponent();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BookAddView_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new BookAddViewModel();
        }

        private void AuthorAddView_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new AuthorAddViewModel();
        }

        private void GenreAddView_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new GenreAddViewModel();
        }

        private void ItemAdd_Click(object sender, RoutedEventArgs e)
        {

            switch (cbAddItem.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("Book added!");
                    break;
                case 1:
                    MessageBox.Show("Author added!");
                    break;
                case 2:
                    if (AddingGenre()) { MessageBox.Show("Genre added!"); }
                    
                   
                    break;
                default:
                    MessageBox.Show("Error!");
                    break;
            }
        }

        private bool AddingGenre()
        {
            Genre genre = new Genre();
            GenreAddView genreAddView = new GenreAddView(genreName.);
            //genre.Name =
            Genres.AddGenre(genre);
            return true;
        }
    }
}
