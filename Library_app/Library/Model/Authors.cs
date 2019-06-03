using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public static class Authors
    {
        public static bool AreRemovedItems { get; set; } = false;
        public static bool IsUpdated { get; set; } = false;
        public static List<Author> AuthorsList { get; set; }

        // tämä pois?
        static Authors()
        {
            Authors.AuthorsList = new List<Author>();
        }

        public static void AddAuthor(Author author)
        {
            AuthorsList.Add(author);
        }
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

        public static Author GetAuthor(int id)
        {
            Author author = new Author();
            foreach (var item in AuthorsList)
            {
                if (item.AuthorId == id) author = item;
            }
            return author;
        }

        //TODO poista myös relation
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
