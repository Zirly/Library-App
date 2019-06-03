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
    /// <summary>
    /// Class that handles connection to MS Access Database, loading and saving data
    /// </summary>
    public static class MSAConnectionDB
    {
        /// <summary>
        /// Returning database connection
        /// </summary>
        /// <returns>OleDbConnection</returns>
        private static OleDbConnection GetDbConnection()
        {
            OleDbConnection connection = new OleDbConnection();
            string connectionString = Properties.Settings.Default.conn_String;
            connection.ConnectionString = connectionString;
            return connection;
        }

        /// <summary>
        /// Call for loading data for each Model class
        /// </summary>
        public static void LoadData()
        {
            Genres.GenresList = ReadGenresFromDatabase();
            Authors.AuthorsList = ReadAuthorsFromDatabase();
            Books.BooksList = ReadBooksFromDatabase();
            ModelRelations.GetBookLists();
        }

        /// <summary>
        /// Loading genres from DB
        /// </summary>
        /// <returns>List of genres</returns>
        private static List<Genre> ReadGenresFromDatabase()
        {
            List<Genre> genres = new List<Genre>();
            try
            {
                OleDbConnection con = GetDbConnection();

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
                        genres.Add(genre);
                    }
                }
                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during reading from DB: " + ex.Message);
            }
            return genres;
        }

        /// <summary>
        /// Loading authors from DB
        /// </summary>
        /// <returns>List of authors</returns>
        private static List<Author> ReadAuthorsFromDatabase()
        {
            List<Author> authors = new List<Author>();
            try
            {
                OleDbConnection con = GetDbConnection();

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

                        Author author = new Author();
                        if (year == 0)
                        {
                            author = new Author(authorId, fName, lName);
                        }
                        else
                        {
                            author = new Author(authorId, fName, lName, year);
                        }
                        authors.Add(author);
                    }
                }
                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during reading from DB: " + ex.Message);
            }
            return authors;
        }
        /// <summary>
        /// Loading books from DB
        /// </summary>
        /// <returns>List of books</returns>
        private static List<Book> ReadBooksFromDatabase()
        {
            List<Book> books = new List<Book>();
            try
            {
                OleDbConnection con = GetDbConnection();

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

                        Book book = new Book();
                        if (year == 0)
                        {
                            book = new Book(bookId, bookTitle, description, isbn, genreId, authorId);
                        }
                        else book = new Book(bookId, bookTitle, description, year, isbn, genreId, authorId);
                        books.Add(book);
                    }
                }
                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during reading from DB: " + ex.Message);
            }
            return books;
        }

        /// <summary>
        /// Saving genre to the database and returning its id
        /// </summary>
        /// <param name="genre">genre to save</param>
        /// <returns>genre's id</returns>
        public static int SaveGenreToDB(Genre genre)
        {
            int id = 0;
            try
            {
                OleDbConnection con = GetDbConnection();

                string query_insert = "insert into [genre_table] (genreName) values (@name)";
                string query_identity = "select @@Identity";

                using (con)
                {
                    using (var cmd = new OleDbCommand(query_insert, con))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@name", genre.Name);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = query_identity;
                        id = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during retrieving scope identity: " + ex.Message);
            }
            return id;
        }

        /// <summary>
        /// Saving book to the database and returning its id
        /// </summary>
        /// <param name="book">book to save</param>
        /// <returns>book's id</returns>
        public static int SaveBookToDB(Book book)
        {
            int id = 0;
            try
            {
                OleDbConnection con = GetDbConnection();

                string query_insert = "insert into [book_table] (title, yearPublish, description, isbn, genre_id, author_id) VALUES (@title,@year,@description,@isbn,@genre_id,@author_id)";
                string query_identity = "select @@Identity";

                using (con)
                {
                    using (var cmd = new OleDbCommand(query_insert, con))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@title", book.Title);
                        cmd.Parameters.AddWithValue("@year", ((object)book.YearPublish) ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@description", ((object)book.Description) ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@isbn", ((object)book.Isbn) ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@genre_id", book.Genre_AtBook.GenreId);
                        cmd.Parameters.AddWithValue("@author_id", book.Author_AtBook.AuthorId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = query_identity;
                        id = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during retrieving scope identity: " + ex.Message);
            }
            return id;
        }
        /// <summary>
        /// Saving author to the database and returning its id
        /// </summary>
        /// <param name="author">author to save</param>
        /// <returns>author's id</returns>
        public static int SaveAuthorToDB(Author author)
        {
            int id = 0;
            try
            {
                OleDbConnection con = GetDbConnection();

                string query_insert = "insert into [author_table] (firstName, lastName, yearBirth) values (@firstName,@lastName,@yearBirth)";
                string query_identity = "select @@Identity";

                using (con)
                {
                    using (var cmd = new OleDbCommand(query_insert, con))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@firstName", ((object)author.FirstName) ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@lastName", author.LastName);
                        cmd.Parameters.AddWithValue("@yearBirth", ((object)author.YearBirth) ?? DBNull.Value);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = query_identity;
                        id = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during retrieving scope identity: " + ex.Message);
            }
            return id;
        }

        /// <summary>
        /// Calls for removing and updating data
        /// </summary>
        /// <returns>true if changes were made, otherwise false</returns>
        public static bool SaveDataToDB()
        {
            bool changesMade = false;
            if (LibraryModel.AreItemsRemoved())
            {
                if (Genres.AreRemovedItems) RemoveGenresFromDB();
                Genres.AreRemovedItems = false;
                if (Authors.AreRemovedItems) RemoveAuthorsFromDB();
                Authors.AreRemovedItems = false;
                if (Books.AreRemovedItems) RemoveBooksFromDB();
                Books.AreRemovedItems = false;
                changesMade = true;
            }
            if (LibraryModel.AreItemsUpdated())
            {
                if (Genres.IsUpdated) UpdateGenresToDB();
                Genres.IsUpdated = false;
                if (Authors.IsUpdated) UpdateAuthorsToDB();
                Authors.IsUpdated = false;
                if (Books.IsUpdated) UpdateBooksToDB();
                Books.IsUpdated = false;
                changesMade = true;
            }
            return changesMade;
        }

        /// <summary>
        /// Checking if there are removed items in local genre's list and removing items from the DB
        /// </summary>
        private static void RemoveGenresFromDB()
        {
            // checking local list against the database table
            List<Genre> oldGenres = ReadGenresFromDatabase();
            List<int> oldIds = new List<int>();
            foreach (Genre oldGenre in oldGenres)
            {
                oldIds.Add(oldGenre.GenreId);
            }
            List<int> newIds = new List<int>();
            foreach (Genre newGenre in Genres.GenresList)
            {
                newIds.Add(newGenre.GenreId);
            }
            foreach (var oldId in oldIds)
            {
                if (!newIds.Contains(oldId))
                {
                    try
                    {
                        OleDbConnection con = GetDbConnection();

                        using (con)
                        {
                            using (var cmd = new OleDbCommand("delete from [genre_table] where genre_id = @id;"))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@id", oldId);
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during delete: " + ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Checking if there are removed items in local author's list and removing items from the DB
        /// </summary>
        private static void RemoveAuthorsFromDB()
        {
            // checking local list against the database table
            List<Author> oldAuthors = ReadAuthorsFromDatabase();
            List<int> oldIds = new List<int>();
            foreach (Author oldAuthor in oldAuthors)
            {
                oldIds.Add(oldAuthor.AuthorId);
            }
            List<int> newIds = new List<int>();
            foreach (Author newAuthor in Authors.AuthorsList)
            {
                newIds.Add(newAuthor.AuthorId);
            }
            foreach (var oldId in oldIds)
            {
                if (!newIds.Contains(oldId))
                {
                    try
                    {
                        OleDbConnection con = GetDbConnection();

                        using (con)
                        {
                            using (var cmd = new OleDbCommand("delete from [author_table] where author_id = @id;"))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@id", oldId);
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during delete: " + ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Checking if there are removed items in local book's list and removing items from the DB
        /// </summary>
        private static void RemoveBooksFromDB()
        {
            // checking local list against the database table
            List<Book> oldBooks = ReadBooksFromDatabase();
            List<int> oldIds = new List<int>();
            foreach (Book oldBook in oldBooks)
            {
                oldIds.Add(oldBook.BookId);
            }
            List<int> newIds = new List<int>();
            foreach (Book newBook in Books.BooksList)
            {
                newIds.Add(newBook.BookId);
            }
            foreach (int oldId in oldIds)
            {
                if (!newIds.Contains(oldId))
                {
                    try
                    {
                        OleDbConnection con = GetDbConnection();

                        using (con)
                        {
                            using (var cmd = new OleDbCommand("delete from [book_table] where book_id = @id;"))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@id", oldId);
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during delete: " + ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Saving updated genre items to the DB
        /// </summary>
        private static void UpdateGenresToDB()
        {
            foreach (Genre genre in Genres.GenresList)
            {
                if (genre.IsUpdated && genre.Name != "")
                {
                    try
                    {
                        OleDbConnection con = GetDbConnection();

                        using (con)
                        {
                            using (var cmd = new OleDbCommand("update [genre_table] set genreName = @name where genre_id = @id;"))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@name", genre.Name);
                                cmd.Parameters.AddWithValue("@id", genre.GenreId);
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during update: " + ex.Message);
                    }
                    genre.IsUpdated = false;
                }
            }
        }
        /// <summary>
        /// Saving updated author items to the DB
        /// </summary>
        private static void UpdateAuthorsToDB()
        {
            foreach (Author author in Authors.AuthorsList)
            {
                if (author.IsUpdated && author.LastName != "")
                {
                    try
                    {
                        OleDbConnection con = GetDbConnection();

                        using (con)
                        {
                            using (var cmd = new OleDbCommand("update [author_table] set firstName = @firstName, lastName = @lastName, yearBirth = @yearBirth where author_id = @id;"))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@firstName", ((object)author.FirstName) ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@lastName", author.LastName);
                                cmd.Parameters.AddWithValue("@yearBirth", ((object)author.YearBirth) ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@id", author.AuthorId);
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during update: " + ex.Message);
                    }
                    author.IsUpdated = false;
                }
            }
        }
        /// <summary>
        /// Saving updated book items to the DB
        /// </summary>
        private static void UpdateBooksToDB()
        {
            foreach (Book book in Books.BooksList)
            {
                if (book.IsUpdated && book.Title != "")
                {
                    try
                    {
                        OleDbConnection con = GetDbConnection();

                        using (con)
                        {
                            using (var cmd = new OleDbCommand("update [book_table] set title = @title, yearPublish = @year, description = @description, isbn = @isbn, genre_id = @genre_id, author_id = @author_id where book_id = @book_id;"))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@title", book.Title);
                                cmd.Parameters.AddWithValue("@year", ((object)book.YearPublish) ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@description", ((object)book.Description) ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@isbn", ((object)book.Isbn) ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@genre_id", book.Genre_AtBook.GenreId);
                                cmd.Parameters.AddWithValue("@author_id", book.Author_AtBook.AuthorId);
                                cmd.Parameters.AddWithValue("@book_id", book.BookId);
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during update: " + ex.Message);
                    }
                    book.IsUpdated = false;
                }
            }
        }
    }
}
