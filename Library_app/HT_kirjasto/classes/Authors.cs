using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_kirjasto.classes
{
    public class Authors
    {
        public List<Author> AuthorsList { get; set; }
        public int Count { get; set; }

        //TODO id
        public void AddAuthor(Author author)
        {
            AuthorsList.Add(author);
            Count++;
        }

        public Author GetAuthor(int id)
        {
            Author author = new Author();
            foreach (var item in AuthorsList)
            {
                if (item.AuthorId == id) author = item;
            }
            return author;
        }
        public Author GetAuthor(string name)
        {
            Author author = new Author();
            foreach (var item in AuthorsList)
            {
                if (item.LastName.ToLower() == name.ToLower()) author = item;
            }
            return author;
        }

        //TODO poista myös relation
        public bool RemoveAuthor(int id)
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
