using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    public static class ModelRelations
    {/*
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
        }*/
        public static void GetBookLists()
        {
            // adding books to its genre
            foreach (var genre in Model.Genres.GenresList)
            {
                foreach (var book in Model.Books.BooksList)
                {
                    if (genre.GenreId == book.Genre_AtBook.GenreId)
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
                    if (author.AuthorId == book.Author_AtBook.AuthorId)
                    {
                        author.AddBook(book);
                    }
                }
            }
        }
    }
}
