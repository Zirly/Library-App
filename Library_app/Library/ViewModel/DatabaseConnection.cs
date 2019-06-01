using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Library.Model;

namespace Library.ViewModel
{
    public static class DatabaseConnection
    {
        public static SqlConnection Get_DB_Connection()
        {
            string cn_String = Properties.Settings.Default.cn_String;
            SqlConnection cn_connection = new SqlConnection(cn_String);
            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            return cn_connection;
        }


        internal static void ReadDataFromDB()
        {
            ReadGenresFromDatabase();
            ReadAuthorsFromDatabase();
            ReadBooksFromDatabase();
            //ModelRelations.GetAuthors();
            ModelRelations.GetBookLists();
        }

        internal static void ReadGenresFromDatabase()
        {
            try
            {
                string connectionString = Properties.Settings.Default.cn_String;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM genre_table;", con);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {                  
                            int genreId = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            Genre genre = new Genre(genreId, name);
                            Genres.AddGenre(genre);
                        }
                    }
                    reader.Close();
                }
                Close_DB_Connection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static bool SaveDataToDB()
        {
            if (LibraryModel.AreChangesMade())
            {
                foreach (var item in Genres.GenresList)
                {
                    if (item.IsChanged)
                    {

                        string connectionString = Properties.Settings.Default.cn_String;
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            try
                            {
                                using (var cmd = new SqlCommand("INSERT INTO genre_table (genre_id, name) VALUES (@genre_id,@name)"))
                                {
                                    cmd.Connection = con;
                                    cmd.Parameters.AddWithValue("@genre_id", item.GenreId);
                                    cmd.Parameters.AddWithValue("@name", item.Name);
                                    con.Open();
                                    if (cmd.ExecuteNonQuery() > 0)
                                    {
                                        MessageBox.Show("Record inserted");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Record failed");
                                    }

                                }


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error during insert: " + ex.Message);
                            }
                        }
                        
                    }

                }
                return true;
                
            }
            return false;
        }

        internal static void ReadAuthorsFromDatabase()
        {
            try
            {
                string connectionString = Properties.Settings.Default.cn_String;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM author_table;", con);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int authorId = reader.GetInt32(0);
                            string fName = reader[1] as string;
                            string lName = reader.GetString(2);
                            int year = reader[3] as int? ?? default(int);
                            Author author = new Author(authorId, fName, lName, year);
                            Authors.AddAuthor(author);
                        }
                    }
                    reader.Close();
                }
                Close_DB_Connection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void ReadBooksFromDatabase()
        {
            try
            {
                string connectionString = Properties.Settings.Default.cn_String;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM book_table;", con);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int bookId = reader.GetInt32(0);
                            string bookTitle = reader.GetString(1);
                            int year = reader[2] as int? ?? default(int);
                            string description = reader[3] as string;            
                            string isbn = reader[4] as string;
                            int genreId = reader.GetInt32(5);
                            int authorId = reader.GetInt32(6);

                            Book book = new Book(bookId, bookTitle, description, year, isbn, genreId, authorId);
                            Books.AddBook(book);
                        }
                    }
                    reader.Close();
                }
                Close_DB_Connection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //updates, inserts
        public static void Execute_SQL(string SQL_Text)
        {
            try
            {
                SqlConnection cn_connection = Get_DB_Connection();
                SqlCommand cmd_Command = new SqlCommand(SQL_Text, cn_connection);
                cmd_Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void Close_DB_Connection()
        {
            string cn_String = Properties.Settings.Default.cn_String;
            SqlConnection cn_connection = new SqlConnection(cn_String);
            if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();

        }

    }
}
