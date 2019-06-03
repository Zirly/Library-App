using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    /// <summary>
    /// Author object and its properties and methods.
    /// </summary>
    public class Author : INotifyPropertyChanged
    {
        // properties
        public bool IsUpdated { get; set; } = false;
        public int AuthorId { get; set; }
        public int? YearBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
 
        public event PropertyChangedEventHandler PropertyChanged;

        // books that are associated with the author
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
                if (string.IsNullOrEmpty(FirstName)) return LastName;
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
        public Author(int id, string fname, string lname)
        {
            AuthorId = id;
            FirstName = fname;
            LastName = lname;
            BooksList = new ObservableCollection<Book>();
        }
        //methods

        /// <summary>
        /// Adding book to author's books' list
        /// </summary>
        /// <param name="book">book to add</param>
        public void AddBook(Book book)
        {
            BooksList.Add(book);
        }

        /// <summary>
        /// Raises an event, when property is changed
        /// </summary>
        /// <param name="name">changed property</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
