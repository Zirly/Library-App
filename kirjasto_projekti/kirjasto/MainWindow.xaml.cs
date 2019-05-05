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

/* Lisätty Database -luokka, joka hoitaa yhteyden tietokantaan ja hakee dataa sql-kommennolla
 * Alustavasti näyttää käyttäliitymässä kirjojen nimet
 * TODO
 * 1) Toimiiko toisellakin koneella? kirjasto > properties > settings > connection_String - sen polku viittaa paikalliseen koneeseen
 * 2) Pitäisikö seuraavastai parsata tietokannan dataa omiksi luokiksi? - onko tämä oikea tapa hoitaa tietokannan dataa?

namespace kirjasto
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
            List<string> myList = new List<string>
            {
                "Berry",
                "Nalle",
                "Busse",
                "Pista",
                "Uhli",
                "Kissa",
                "Arttu",
                "Marketa"
            };
            myListBox.ItemsSource = myList; */
            string sql = "SELECT title FROM book_table";
            DataTable tbl = Database.Get_DataTable(sql);
            if (tbl.Rows.Count >= 0)
            {
                List<string> bookTitles = new List<string>();
                foreach (DataRow row in tbl.Rows)
                {
                    bookTitles.Add(row["title"].ToString());
                }
                myListBox.ItemsSource = bookTitles;
            }
        }
    }
}
