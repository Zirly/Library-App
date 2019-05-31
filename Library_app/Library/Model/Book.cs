using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        //
        private string title;
        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                OnPropertyChanged("Title");
            }
        }
        private int bookId;
        public int BookId
        {
            get { return bookId; }
            set
            {
                bookId = value;
                OnPropertyChanged("BookId");
            }
        }
        //
        //public int BookId { get; set; }
        //public string Title { get; set; }
        public object Description { get; set; }
        public int? YearPublish { get; set; }
        public string Isbn { get; set; }
        public Genre Genre_AtBook { get; set; }
        public List<Author> AuthorsList { get; set; }
        

        public Book() { }

        public Book(int id, string title, string description, int year, string isbn, int genreId)
        {
            BookId = id;
            Title = title;
            Description = description;
            YearPublish = year;
            Isbn = isbn;
            AttachGenre(genreId);
            AuthorsList = new List<Author>();
        }
        public void AddAuthor(Author author)
        {
            AuthorsList.Add(author);
        }

        public void AttachGenre(int id)
        {
            foreach (var item in Genres.GenresList)
            {
                if (item.GenreId == id)
                {
                    Genre_AtBook = item;
                }
            }
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
