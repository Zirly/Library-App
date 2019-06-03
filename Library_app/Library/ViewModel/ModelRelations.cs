using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    /// <summary>
    /// Static class that handles the connections between book-genre-author when reading from the DB
    /// </summary>
    public static class ModelRelations
    {
        /// <summary>
        /// Assigning each genre and author all associated books
        /// </summary>
        public static void GetBookLists()
        {
            // adding books to its genre
            foreach (var genre in Model.Genres.GenresList)
            {
                foreach (var book in Model.Books.BooksList)
                {
                    // book should never be without genre, but it could happen if loading data from db fails
                    if ((book.Genre_AtBook != null) && (genre.GenreId == book.Genre_AtBook.GenreId))
                    {
                        genre.AddBook(book);
                    }
                }
            }
            // adding books to its author
            foreach (var author in Model.Authors.AuthorsList)
            {
                foreach (var book in Model.Books.BooksList)
                {
                    if ((book.Author_AtBook != null) && (author.AuthorId == book.Author_AtBook.AuthorId))
                    {
                        author.AddBook(book);
                    }
                }
            }
        }
    }
}
