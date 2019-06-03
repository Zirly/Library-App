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

        /// <summary>
        /// Cancel button
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Showing book's adding view
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void BookAddView_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new BookAddViewModel();
        }
        /// <summary>
        /// Showing author's adding view
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void AuthorAddView_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new AuthorAddViewModel();
        }
        /// <summary>
        /// Showing genre's adding view
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void GenreAddView_Selected(object sender, RoutedEventArgs e)
        {
            DataContext = new GenreAddViewModel();
        }
        /// <summary>
        /// Add- button's click
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void ItemAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isAdded = false;

                switch (cbAddItem.SelectedIndex)
                {
                    case 0:
                        if (AddItemBook())
                        {
                            MessageBox.Show("Book added!");
                            isAdded = true;
                        }
                        break;
                    case 1:
                        if (AddItemAuthor())
                        {
                            MessageBox.Show("Author added!");
                            isAdded = true;
                        }
                        break;
                    case 2:
                        if (AddItemGenre())
                        {
                            MessageBox.Show("Genre added!");
                            isAdded = true;
                        }                           
                        break;
                    default:
                        MessageBox.Show("Error!");
                        break;
                }
            if (isAdded) Close();
        }

        /// <summary>
        /// Checking genre's input and sending it to the database
        /// </summary>
        /// <returns>True if genre sent to DB, otherwise false</returns>
        private bool AddItemGenre()
        {
            GenreAddViewModel viewmodel = (GenreAddViewModel)DataContext;
            Genre genre = viewmodel.MyGenre;
            if (string.IsNullOrEmpty(genre.Name))
            {
                MessageBox.Show("Name cannnot be empty.");
                return false;
            }
            foreach (var g in Genres.GenresList)
            {
                if (g.Name == genre.Name)
                {
                    MessageBox.Show("Genre already exists!");
                    return false;
                }
            }
            int id = MSAConnectionDB.SaveGenreToDB(genre);
            genre.GenreId = id;
            Genres.AddGenre(genre);
            ActivateMainWindow();
            return true;
        }

        /// <summary>
        /// Checking author's input and sending it to the database
        /// </summary>
        /// <returns>True if author sent to DB, otherwise false</returns>
        private bool AddItemAuthor()
        {
            AuthorAddViewModel viewmodel = (AuthorAddViewModel)DataContext;
            Author author = viewmodel.MyAuthor;
            if (string.IsNullOrEmpty(author.LastName))
            {
                MessageBox.Show("Last name cannnot be empty.");
                return false;
            }
            int id = MSAConnectionDB.SaveAuthorToDB(author);
            author.AuthorId = id;
            Authors.AddAuthor(author);       
            ActivateMainWindow();
            return true;
        }

        /// <summary>
        /// Checking books's input and sending it to the database
        /// </summary>
        /// <returns>True if book sent to DB, otherwise false</returns>
        private bool AddItemBook()
        {
            BookAddViewModel viewmodel = (BookAddViewModel)DataContext;
            Book book = viewmodel.MyBook;

            if (string.IsNullOrEmpty(book.Title))
            {
                MessageBox.Show("Title cannnot be empty.");
                return false;
            }
            
            if (book.Author_AtBook == null)
            {
                MessageBox.Show("Author must be added.");
                return false;
            }
            if (book.Genre_AtBook == null)
            {
                MessageBox.Show("Genre must be added.");
                return false;
            }

            int id = MSAConnectionDB.SaveBookToDB(book);
            book.BookId = id;
            Books.AddBook(book);
            Genres.AddBookToGenre(book, book.Genre_AtBook);
            Authors.AddBookToAuthor(book, book.Author_AtBook);
            ActivateMainWindow();
            return true;
        }

        /// <summary>
        /// Loading right context to the main window
        /// </summary>
        private void ActivateMainWindow()
        {
            var mw = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(window => window is MainWindow) as MainWindow;

            switch (mw.comboBox.SelectedIndex)
            {
                case 0:
                    mw.DataContext = new
                    {
                        collection = new BooksListViewModel(),
                        detail = new BookDetailViewModel(Books.GetBook(1))
                    };
                    break;
                case 1:
                    mw.DataContext = new
                    {
                        collection = new AuthorsListViewModel(),
                        detail = new AuthorDetailViewModel(Authors.GetAuthor(1))
                    };
                    break;
                case 2:
                    mw.DataContext = new
                    {
                        collection = new GenresListViewModel(),
                        detail = new GenreDetailViewModel(Genres.GetGenre(1))
                    };
                    break;
                default:
                    break;
            }
        }
    }
}
