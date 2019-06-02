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
        public static bool IsChanged { get; set; } = false;
        public static List<Author> AuthorsList { get; set; }
        public static int LastIndex { get; set; }

        // tämä pois?
        static Authors()
        {
            Authors.AuthorsList = new List<Author>();
            Authors.LastIndex = GetLastIndex() + 1;

        }

        private static int GetLastIndex()
        {
            int id = 0;
            foreach (var item in AuthorsList)
            {
                if (item.AuthorId > id) id = item.AuthorId;
            }
            return id;
        }

        public static void AddAuthor(Author author)
        {
            author.AuthorId = LastIndex;
            LastIndex++;
            AuthorsList.Add(author);
        }
        public static void AddBookToAuthor(Book book, Author author)
        {
            foreach (var a in AuthorsList)
            {
                if (a == author)
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
        public static Author GetAuthor(string name)
        {
            Author author = new Author();
            foreach (var item in AuthorsList)
            {
                if (item.FullName == name) author = item;
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
        public static bool RemoveAuthor(Author author)
        {
            foreach (var item in AuthorsList)
            {
                if (item == author)
                {
                    AuthorsList.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public static bool RemoveAuthorByName(string name)
        {
            foreach (Author author in AuthorsList)
            {
                if (author.FullName == name)
                {
                    AuthorsList.Remove(author);
                    return true;
                }
            }
            return false;
        }
    }

}
