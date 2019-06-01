using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Author
    {
        public bool IsChanged { get; set; } = false;
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? YearBirth { get; set; }
        private ObservableCollection<Book> _booksList = new ObservableCollection<Book>();
        public ObservableCollection<Book> BooksList
        {
            get { return _booksList; }
            set
            {
                _booksList = value;
            }
        }
       
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
            BooksList = new ObservableCollection<Book>();
        }
        //methods
        public void AddBook(Book book)
        {
            BooksList.Add(book);
        }
    }
}
