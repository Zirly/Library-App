using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? YearBirth { get; set; }
        public List<Book> BooksList { get; set; }
        public string FullName
        {
            get
            {
                if (FirstName == null) return LastName;
                return LastName + ", " + FirstName;
            }
        }
        //constructors
        public Author()
        {

        }
        public Author(int id, string fname, string lname, int year)
        {
            AuthorId = id;
            FirstName = fname;
            LastName = lname;
            YearBirth = year;
            BooksList = new List<Book>();
        }
        //methods
        public void AddBook(Book book)
        {
            BooksList.Add(book);
        }
    }
}
