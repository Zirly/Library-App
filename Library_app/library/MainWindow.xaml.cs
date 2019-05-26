using System;
using System.Collections.Generic;
using System.Data;
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
        }

        private void TestDB_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM book_table";
            DataTable tbl = ViewModel.DatabaseConnection.Get_DataTable(sql);

            if (tbl.Rows.Count >= 0)
            {
                List<string> bookTitles = new List<string>();
                foreach (DataRow row in tbl.Rows)
                {
                    bookTitles.Add(row["title"].ToString());
                }
                lstTest.ItemsSource = bookTitles;
            }
        }
    }
}
