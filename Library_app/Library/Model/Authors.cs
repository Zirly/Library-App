using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    /// <summary>
    /// Static class that holds together all the authors
    /// </summary>
    public static class Authors
    {
        // properties
        public static bool AreRemovedItems { get; set; } = false;
        public static bool IsUpdated { get; set; } = false;
        public static List<Author> AuthorsList { get; set; }

        // constructor
        static Authors()
        {
            Authors.AuthorsList = new List<Author>();
        }

        // methods
        /// <summary>
        /// Adding author to the list
        /// </summary>
        /// <param name="author">Author to add</param>
        public static void AddAuthor(Author author)
        {
            AuthorsList.Add(author);
        }
        /// <summary>
        /// Connecting book to an author
        /// </summary>
        /// <param name="book">book to add</param>
        /// <param name="author">author to get a book</param>
        public static void AddBookToAuthor(Book book, Author author)
        {
            foreach (var a in AuthorsList)
            {
                if (a.AuthorId == author.AuthorId)
                {
                    a.AddBook(book);
                }
            }
        }

        /// <summary>
        /// Finding author based on id
        /// </summary>
        /// <param name="id">author's id</param>
        /// <returns>found author</returns>
        public static Author GetAuthor(int id)
        {
            Author author = new Author();
            foreach (var item in AuthorsList)
            {
                if (item.AuthorId == id) author = item;
            }
            return author;
        }

        /// <summary>
        /// Removing author from the list
        /// </summary>
        /// <param name="id">author's id</param>
        /// <returns>true, if author removed, otherwise false</returns>
        public static bool RemoveAuthor(int id)
        {
            foreach (var author in AuthorsList)
            {
                if (author.AuthorId == id)
                {
                    AuthorsList.Remove(author);
                    return true;
                }
            }
            return false;
        }
    }
}
