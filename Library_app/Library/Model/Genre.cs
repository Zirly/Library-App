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
    /// Genre object and its properties and methods.
    /// </summary>
    public class Genre : INotifyPropertyChanged
    {
        // properties
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsUpdated { get; set; } = false;
        public int GenreId { get; set; }

        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }
        // books that are associated with the genre
        private ObservableCollection<Book> _booksList = new ObservableCollection<Book>();
        public ObservableCollection<Book> BooksList
        {
            get { return this._booksList; }
            set
            {
                this._booksList = value;
                OnPropertyChanged("BooksList");
            }
        }

        //constructors
        public Genre() { }
        public Genre(int id, string name)
        {
            GenreId = id;
            Name = name;
            BooksList = new ObservableCollection<Book>();
        }

        /// <summary>
        /// Adding book to genre's books' list
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
