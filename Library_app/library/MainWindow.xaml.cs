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
            //string sql = "SELECT * FROM book_table";
            /*
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
            */
            List<string> testLista = new List<string>();

            try
            {
                SqlConnection connection = ViewModel.DatabaseConnection.Get_DB_Connection();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM book_table;", connection);
                    //connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Model.Book book = new Model.Book();
                            book.BookId = reader.GetInt32(0);
                            book.Title = reader.GetString(1);
                            book.Description = reader[2] as string;
                            book.YearPublish = reader[3] as int? ?? default(int);
                            book.Isbn = reader[4] as string;
                            book.GenreId = reader.GetInt32(5);
                            Model.Books.AddBook(book);

                        }
                    }
                    reader.Close();
                }
                ViewModel.DatabaseConnection.Close_DB_Connection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
