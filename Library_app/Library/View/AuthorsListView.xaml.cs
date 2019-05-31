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
using Library.ViewModel;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for AuthorsListView.xaml
    /// </summary>
    public partial class AuthorsListView : UserControl
    {
        public AuthorsListView()
        {
            InitializeComponent();
            
        }

        private void LstAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Author selected = (Author)lstAuthors.SelectedItem;
            var mw = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(window => window is MainWindow) as MainWindow;

            mw.DataContext = new
            {
                collection = new AuthorsListViewModel(),
                detail = new AuthorDetailViewModel(selected)
            };


        }
    }
}
