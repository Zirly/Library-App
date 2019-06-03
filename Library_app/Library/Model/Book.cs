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
            get { return title; }
            set
            {
                title = value;
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
        public bool IsUpdated { get; set; } = false;
        public object Description { get; set; }
        public int? YearPublish { get; set; }
        public string Isbn { get; set; }
        public Genre Genre_AtBook { get; set; }
        public Author Author_AtBook { get; set; }
        

        public Book() { }

        public Book(int id, string title, string description, int year, string isbn, int genreId, int authorId)
        {
            BookId = id;
            Title = title;
            Description = description;
            YearPublish = year;
            Isbn = isbn;
            AttachGenre(genreId);
            AttachAuthor(authorId);
        }
        public Book(int id, string title, string description, string isbn, int genreId, int authorId)
        {
            BookId = id;
            Title = title;
            Description = description;
            Isbn = isbn;
            AttachGenre(genreId);
            AttachAuthor(authorId);
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
        public void AttachAuthor(int id)
        {
            foreach (var item in Authors.AuthorsList)
            {
                if (item.AuthorId == id)
                {
                    Author_AtBook = item;
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
