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
    /// Interaction logic for AuthorDetailView.xaml
    /// </summary>
    public partial class AuthorDetailView : UserControl
    {
        public AuthorDetailView()
        {
            InitializeComponent();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Authors.AuthorsList.Count < 1)
            {
                MessageBox.Show("No authors to remove.");
                return;
            }
            AuthorDetailViewModel viewmodel = (AuthorDetailViewModel)DataContext;
            Author author = Authors.GetAuthor(viewmodel.MyAuthor.AuthorId);
            if (author.BooksList.Count > 0) MessageBox.Show("Author cannot be removed. Associated books must be removed first.");
            else if (MessageBox.Show("Are you sure you want to remove the author?", "Remove author", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Authors.RemoveAuthor(author.AuthorId);
                Authors.AreRemovedItems = true;
                var mw = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(window => window is MainWindow) as MainWindow;

                mw.DataContext = new
                {
                    collection = new AuthorsListViewModel(),
                    detail = new AuthorDetailViewModel(Authors.GetAuthor(Authors.AuthorsList.Count))
                };
            }
        }

        private void txtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            AuthorDetailViewModel viewmodel = (AuthorDetailViewModel)DataContext;
            Author author = viewmodel.MyAuthor;
            author.IsUpdated = true;
            Authors.IsUpdated = true;
        }

        private void TxtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Field cannot be empty!");
                AuthorDetailViewModel viewmodel = (AuthorDetailViewModel)DataContext;
                Author author = viewmodel.MyAuthor;
                txtLastName.Text = author.LastName;
            }
        }

        private void TxtYear_LostFocus(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtYear.Text, out int year))
            {
                if (year < 1 || year > 2050)
                {
                    MessageBox.Show("Year field not valid.");
                    AuthorDetailViewModel viewmodel = (AuthorDetailViewModel)DataContext;
                    Author author = viewmodel.MyAuthor;
                    txtYear.Text = author.YearBirth.ToString();
                }
            } 
        }
    }
}
