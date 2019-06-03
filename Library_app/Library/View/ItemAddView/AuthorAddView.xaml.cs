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
using Library.ViewModel.ItemAddViewModel;
using Library.Model;

namespace Library.View.ItemAddView
{
    /// <summary>
    /// Interaction logic for AuthorAddView.xaml
    /// </summary>
    public partial class AuthorAddView : UserControl
    {
        public AuthorAddView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checking if the input in author's year's field is valid
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The instance containing the event data</param>
        private void AuthorYearBirth_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(authorYearBirth.Text)) return;
            if (int.TryParse(authorYearBirth.Text, out int year))
            {
                if (year < 1 || year > 2050)
                {
                    MessageBox.Show("Year field not valid.");
                    authorYearBirth.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Year field not valid.");
                authorYearBirth.Text = null;
            }
        }
    }
}
