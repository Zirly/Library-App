using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    public static class BookViewModel
    {
        public static void GetAuthors()
        {
            foreach (var relation in Model.Relations.RelationsList)
            {
                
                foreach (var book in Model.Books.BooksList)
                {   
                    if (relation.BookId == book.BookId)
                    {
                        foreach (var author in Model.Authors.AuthorsList)
                        {
                            if (relation.AuthorId == author.AuthorId)
                            {
                                book.AddAuthor(author);
                                author.AddBook(book);
                            }
                        }
                    }
                    
                }
            }
        }
        public static void GetBooks()
        {
            foreach (var genre in Model.Genres.GenresList)
            {
                foreach (var book in Model.Books.BooksList)
                {
                    if (genre.Name == book.Genre_AtBook.Name)
                    {
                        genre.AddBook(book);
                    }
                }
            }
        }
    }
}
