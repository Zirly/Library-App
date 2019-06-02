using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;

namespace Library.ViewModel
{
    public static class MSAConnectionDB
    {
        public static void MakeConnection()
        {
            ReadGenresFromDatabase();
            ReadAuthorsFromDatabase();
            ReadBooksFromDatabase();
            ModelRelations.GetBookLists();
        }

        public static void ReadGenresFromDatabase()
        {

            try
            {
                OleDbConnection con = new OleDbConnection();

                string connectionString = Properties.Settings.Default.conn_String;
                con.ConnectionString = connectionString;
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from [genre_table]";
                cmd.Connection = con;
                OleDbDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        int genreId = rd.GetInt32(0);
                        string name = rd.GetString(1);
                        Genre genre = new Genre(genreId, name);
                        Genres.AddGenre(genre);
                    }
                }
                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ReadAuthorsFromDatabase()
        {

            try
            {
                OleDbConnection con = new OleDbConnection();

                string connectionString = Properties.Settings.Default.conn_String;
                con.ConnectionString = connectionString;
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from [author_table]";
                cmd.Connection = con;
                OleDbDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        int authorId = rd.GetInt32(0);
                        string fName = rd[1] as string;
                        string lName = rd.GetString(2);
                        int year = rd[3] as int? ?? default(int);
                        Author author = new Author(authorId, fName, lName, year);
                        Authors.AddAuthor(author);
                    }
                }
                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ReadBooksFromDatabase()
        {

            try
            {
                OleDbConnection con = new OleDbConnection();

                string connectionString = Properties.Settings.Default.conn_String;
                con.ConnectionString = connectionString;
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from [book_table]";
                cmd.Connection = con;
                OleDbDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        int bookId = rd.GetInt32(0);
                        string bookTitle = rd.GetString(1);
                        int year = rd[2] as int? ?? default(int);
                        string description = rd[3] as string;
                        string isbn = rd[4] as string;
                        int genreId = rd.GetInt32(5);
                        int authorId = rd.GetInt32(6);

                        Book book = new Book(bookId, bookTitle, description, year, isbn, genreId, authorId);
                        Books.AddBook(book);
                    }
                }
                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool SaveDataToDB()
        {
            if (LibraryModel.AreChangesMade())
            {
                if (Genres.IsChanged) SaveNewGenresToDB();
                Genres.IsChanged = false;
                if (Authors.IsChanged) SaveNewAuthorsToDB();
                Authors.IsChanged = false;
                if (Books.IsChanged) SaveNewBooksToDB();
                Books.IsChanged = false;
                return true;
            }
            return false;
            
        }

        private static void SaveNewBooksToDB()
        {
            foreach (Book book in Books.BooksList)
            {
                if (book.IsChanged)
                {
                    try
                    {
                        OleDbConnection con = new OleDbConnection();

                        string connectionString = Properties.Settings.Default.conn_String;
                        con.ConnectionString = connectionString;

                        using (con)
                        {
                            using (var cmd = new OleDbCommand("insert into [book_table] (book_id, title, yearPublish, description, isbn, genre_id, author_id) VALUES (@book_id,@title,@year,@description,@isbn,@genre_id,@author_id)"))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@book_id", book.BookId);
                                cmd.Parameters.AddWithValue("@title", book.Title);
                                cmd.Parameters.AddWithValue("@year", ((object)book.YearPublish) ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@description", ((object)book.Description) ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@isbn", ((object)book.Isbn) ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@genre_id", book.Genre_AtBook.GenreId);
                                cmd.Parameters.AddWithValue("@author_id", book.Author_AtBook.AuthorId);
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    book.IsChanged = false;
                }
            }
        }

        private static void SaveNewAuthorsToDB()
        {
            foreach (Author author in Authors.AuthorsList)
            {
                if (author.IsChanged)
                {
                    try
                    {
                        OleDbConnection con = new OleDbConnection();

                        string connectionString = Properties.Settings.Default.conn_String;
                        con.ConnectionString = connectionString;

                        using (con)
                        {
                            using (var cmd = new OleDbCommand("insert into [author_table] (author_id, firstName, lastName, yearBirth) VALUES (@author_id,@firstName,@lastName,@yearBirth)"))
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during insert: " + ex.Message);
                    }
                    author.IsChanged = false;
                }
            }
        }

        private static void SaveNewGenresToDB()
        {
            foreach (Genre genre in Genres.GenresList)
            {
                if (genre.IsChanged)
                {
                    try
                    {
                        OleDbConnection con = new OleDbConnection();

                        string connectionString = Properties.Settings.Default.conn_String;
                        con.ConnectionString = connectionString;

                        using (con)
                        {
                            using (var cmd = new OleDbCommand("insert into [genre_table] (genreName) VALUES (@name)"))
                            {
                                cmd.Connection = con;
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during insert: " + ex.Message);
                    }
                    genre.IsChanged = false;
                }
            }
        }
    }
}
