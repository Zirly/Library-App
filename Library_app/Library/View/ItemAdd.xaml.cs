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
using Library.ViewModel;

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
                    BookAddViewModel ba = (BookAddViewModel)DataContext;
                    Book book = ba.MyBook;
                    Books.AddBook(book);
                    Genres.AddBookToGenre(book, book.Genre_AtBook);
                    MessageBox.Show("Book added!");
                    break;
                case 1:
                    AuthorAddViewModel aa = (AuthorAddViewModel)DataContext;
                    Author author = aa.MyAuthor;

                    Authors.AddAuthor(author);
                    MessageBox.Show("Author added!");
                    break;
                case 2:
                    GenreAddViewModel ga = (GenreAddViewModel)DataContext;
                    Genre genre = ga.MyGenre;

                    Genres.AddGenre(genre);
                    MessageBox.Show("Genre added!");
                    break;
                default:
                    MessageBox.Show("Error!");
                    break;
            }
            Close();
        }
    }
}
