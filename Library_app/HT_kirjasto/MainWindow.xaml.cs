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

namespace HT_kirjasto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*
            string name = "horror";
            int id = 7;

            string sSQL = "INSERT INTO genre_table (genre_id, name) VALUES('" + id + "', '" + name + "');";
            Database_class.Execute_SQL(sSQL);
            name = "drama";
            id = 8;
            sSQL = "INSERT INTO genre_table ([genre_id],[name]) VALUES('" + id + "', '" + name + "');";
            Database_class.Execute_SQL(sSQL);
            */
            string sql = "SELECT * FROM genre_table";
            DataTable tbl = Database_class.Get_DataTable(sql);

            if (tbl.Rows.Count >= 0)
            {
                List<string> myList = new List<string>();
                foreach (DataRow row in tbl.Rows)
                {
                    myList.Add(row["name"].ToString());
                }
                myListBox.ItemsSource = myList;
            }

            List<Bookx> lista = new List<Bookx>();
            lista.Add(new Bookx() {Book = "dsf", Year = "fds", Author = "fds", Genre = "sfdf", ISBN = "fsdf" });
            lista.Add(new Bookx() {Book = "aaa", Year = "bbb", Author = "ccc", Genre = "ddd", ISBN = "eee" });
            lista.Add(new Bookx() {Book = "fff", Year = "ggg", Author = "hhh", Genre = "iii", ISBN = "jjj" });
            dataGrid.ItemsSource = lista;


            /*
            DataTable dg = Database_class.Get_DataTable(sql);
            if (dg.Rows.Count >= 0)
            {
                List<string> myList = new List<string>();
                foreach (DataRow row in dg.Rows)
                {
                  
                   dataGrid.Items.Add(Book = "fsd", )
    
                   // dataGrid.Rows.Add(row["book_id"].ToString());
                }
            } */

        }
    }
    public class Bookx
    {
        public string Book { get; set; }
        public string Year { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
    }
}
