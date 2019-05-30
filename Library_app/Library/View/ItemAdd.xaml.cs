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
            

            //AddingGenre(ga.MyText);
            
            

            
            switch (cbAddItem.SelectedIndex)
            {
                case 0:
                    BookAddViewModel ba = (BookAddViewModel)DataContext;
                    AddingBook(ba.MyBookTitle);
                    break;
                case 1:
                    AuthorAddViewModel aa = (AuthorAddViewModel)DataContext;
                    AddingAuthor(aa.MyFirstName);
                    break;
                case 2:
                    GenreAddViewModel ga = (GenreAddViewModel)DataContext;
                    AddingGenre(ga.MyText);
                    break;
                default:
                    MessageBox.Show("Error!");
                    break;
            } 
        }

        private bool AddingBook(string text)
        {
            Book book = new Book();
            book.Title = text;
            Books.AddBook(book);
            MessageBox.Show("Book added!");
            return true;
        }

        private bool AddingAuthor(string text)
        {
            Author author = new Author();
            author.FirstName = text;
            Authors.AddAuthor(author);
            MessageBox.Show("Author added!");
            return true;
        }

        private bool AddingGenre(string text)
        {
            Genre genre = new Genre();
            genre.Name = text;
            Genres.AddGenre(genre);
            MessageBox.Show("Genre added!");
            return true;
        }
    }
}
