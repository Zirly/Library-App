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
            string fullname = txtFullName.Text;
            Author author = Authors.GetAuthor(fullname);
            if (author.BooksList.Count > 0) MessageBox.Show("Author cannot be removed. His/her books must be removed first.");
            else if (MessageBox.Show("Are you sure you want to remove the author?", "Remove author", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Authors.RemoveAuthor(author);
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
    }
}
