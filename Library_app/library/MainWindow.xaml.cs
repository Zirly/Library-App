using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DatabaseConnection.ReadDataFromDB();
            
            lstBooks.ItemsSource = Books.BooksList;
            
            lstBooks.SelectedIndex = 0;
        }

        private void TestDB_Click(object sender, RoutedEventArgs e)
        {
            
            //lstBooks.ItemsSource = Books.BooksList;     
        }

        private void LstBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selected = (Book)lstBooks.SelectedItem;
            BookDetailControl.detailData.DataContext = selected;
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            lstBooks.ItemsSource = Books.BooksList;
            lstBooks.Items.Refresh();
            lstBooks.SelectedIndex = 0;
        }
    }
}
