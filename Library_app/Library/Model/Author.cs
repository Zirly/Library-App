using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Author : INotifyPropertyChanged
    {
        public bool IsUpdated { get; set; } = false;
        public bool IsChanged { get; set; } = false;
        public int AuthorId { get; set; }
        public int? YearBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int? YearBirth { get; set; }
        private ObservableCollection<Book> _booksList = new ObservableCollection<Book>();

        public event PropertyChangedEventHandler PropertyChanged;

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
        public void AddBook(Book book)
        {
            BooksList.Add(book);
        }

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
