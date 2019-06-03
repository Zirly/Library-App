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
    /// Interaction logic for GenresListView.xaml
    /// </summary>
    public partial class GenresListView : UserControl
    {
        public GenresListView()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Reacting to the change of selection and showing the selected genre in the adjacent view
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void LstGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Genre selected = (Genre)lstGenres.SelectedItem;
            var mw = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(window => window is MainWindow) as MainWindow;

            mw.DataContext = new
            {
                collection = new GenresListViewModel(),
                detail = new GenreDetailViewModel(selected)
            };
        }
    }
}
