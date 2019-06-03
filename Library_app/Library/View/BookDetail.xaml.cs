﻿using System;
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
using Library.ViewModel;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for BookDetail.xaml
    /// </summary>
    public partial class BookDetail : UserControl
    {
        public BookDetail()
        {
            InitializeComponent();
        }

        private void BookRemove_Click(object sender, RoutedEventArgs e)
        {
            if (Books.BooksList.Count < 1)
            {
                MessageBox.Show("No books to remove.");
                return;
            }
            if (MessageBox.Show("Are you sure you want to remove the book?", "Remove Book", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                BookDetailViewModel viewmodel = (BookDetailViewModel)DataContext;
                Book book = Books.GetBook(viewmodel.MyBook.BookId);
                foreach (Author author in Authors.AuthorsList)
                {
                    if (author.BooksList.Contains(book)) author.BooksList.Remove(book);
                }
                foreach (Genre genre in Genres.GenresList)
                {
                    if (genre.BooksList.Contains(book)) genre.BooksList.Remove(book);
                }
                Books.RemoveBook(book.BookId);
                Books.AreRemovedItems = true;
                var mw = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(window => window is MainWindow) as MainWindow;

                mw.DataContext = new
                {
                    collection = new BooksListViewModel(),
                    detail = new BookDetailViewModel(Books.GetBook(Books.BooksList.Count))
                };
            }
        }

        private void txtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            BookDetailViewModel viewmodel = (BookDetailViewModel)DataContext;
            Book book = viewmodel.MyBook;
            book.IsUpdated = true;
            Books.IsUpdated = true;
        }

        private void TxtBookTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookTitle.Text))
            {
                MessageBox.Show("Field cannot be empty!");
                BookDetailViewModel viewmodel = (BookDetailViewModel)DataContext;
                Book book = viewmodel.MyBook;
                txtBookTitle.Text = book.Title;
            }
        }

        private void TxtYear_LostFocus(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtYear.Text, out int year))
            {
                if (year < 1 || year > 2050)
                {
                    MessageBox.Show("Year field not valid.");
                    BookDetailViewModel viewmodel = (BookDetailViewModel)DataContext;
                    Book book = viewmodel.MyBook;
                    txtYear.Text = book.YearPublish.ToString();
                }
            }
        }
    }
}
