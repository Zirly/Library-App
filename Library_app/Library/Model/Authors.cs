using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public static class Authors
    {
        public static List<Author> AuthorsList { get; set; }
        public static int LastIndex { get; set; }

        // tämä pois?
        static Authors()
        {
            Authors.AuthorsList = new List<Author>();
            Authors.LastIndex = AuthorsList.Count + 1;

        }

        //TODO id
        public static void AddAuthor(Author author)
        {
            author.AuthorId = LastIndex;
            LastIndex++;
            AuthorsList.Add(author);
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
                if (item.LastName.ToLower() == name.ToLower()) author = item;
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
