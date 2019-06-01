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

        public static void SaveDataToDB()
        {
            if (LibraryModel.AreChangesMade())
            {
               if (Genres.IsChanged) SaveNewGenresToDB();
               if (Authors.IsChanged) SaveNewAuthorsToDB();
            }
        }

        internal static void SaveNewAuthorsToDB()
        {
            foreach (var author in Authors.AuthorsList)
            {
                if (author.IsChanged)
                {
                    string connectionString = Properties.Settings.Default.cn_String;
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        try
                        {
                            using (var cmd = new SqlCommand("INSERT INTO author_table (author_id, firstName, lastName, yearBirth) VALUES (@author_id,@firstName,@lastName,@yearBirth)"))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@author_id", author.AuthorId);
                                cmd.Parameters.AddWithValue("@firstName", ((object)author.FirstName) ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@lastName", author.LastName);
                                cmd.Parameters.AddWithValue("@yearBirth", ((object)author.YearBirth) ?? DBNull.Value);
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
        }

        internal static void SaveNewGenresToDB()
        {

            foreach (var genre in Genres.GenresList)
            {
                if (genre.IsChanged)
                {
                    string connectionString = Properties.Settings.Default.cn_String;
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        try
                        {
                            using (var cmd = new SqlCommand("INSERT INTO genre_table (genre_id, name) VALUES (@genre_id,@name)"))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@genre_id", genre.GenreId);
                                cmd.Parameters.AddWithValue("@name", genre.Name);
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
