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
        public static DataTable Get_DataTable(string SQL_Text)
        {
            SqlConnection cn_connection = Get_DB_Connection();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(SQL_Text, cn_connection);
            adapter.Fill(table);
            return table;

        }

        internal static void ReadRelationsFromDatabase()
        {
            try
            {
                SqlConnection connection = Get_DB_Connection();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM book_author;", connection);
                    //connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Relation relation = new Relation();
                            relation.RelationId = reader.GetInt32(0);
                            relation.BookId = reader.GetInt32(1);
                            relation.AuthorId = reader.GetInt32(2);
                            Relations.AddRelation(relation);
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

        internal static void ReadGenresFromDatabase()
        {
            try
            {
                SqlConnection connection = Get_DB_Connection();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM genre_table;", connection);
                    //connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Genre genre = new Genre();
                            genre.GenreId = reader.GetInt32(0);
                            genre.Name = reader.GetString(1);
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

        internal static void ReadAuthorsFromDatabase()
        {
            try
            {
                SqlConnection connection = Get_DB_Connection();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM author_table;", connection);
                    //connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Author author = new Author();
                            author.AuthorId = reader.GetInt32(0);
                            author.FirstName = reader[1] as string;
                            author.LastName = reader.GetString(2);
                            author.YearBirth = reader[3] as int? ?? default(int);
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
                SqlConnection connection = Get_DB_Connection();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM book_table;", connection);
                    //connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Book book = new Book();
                            book.BookId = reader.GetInt32(0);
                            book.Title = reader.GetString(1);
                            book.Description = reader[2] as string;
                            book.YearPublish = reader[3] as int? ?? default(int);
                            book.Isbn = reader[4] as string;
                            book.GenreId = reader.GetInt32(5);
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
            SqlConnection cn_connection = Get_DB_Connection();
            SqlCommand cmd_Command = new SqlCommand(SQL_Text, cn_connection);
            cmd_Command.ExecuteNonQuery();
        }
        public static void Close_DB_Connection()
        {
            string cn_String = Properties.Settings.Default.cn_String;
            SqlConnection cn_connection = new SqlConnection(cn_String);
            if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();

        }

    }
}
