using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    /// <summary>
    /// Book object and its properties and methods.
    /// </summary>
    public class Book : INotifyPropertyChanged
    {
        // properties
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsUpdated { get; set; } = false;
        public object Description { get; set; }
        public int? YearPublish { get; set; }
        public string Isbn { get; set; }
        public Genre Genre_AtBook { get; set; }
        public Author Author_AtBook { get; set; }

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
        
        // constructors
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

        /// <summary>
        /// Attaching genre to the book, based on genre's id
        /// </summary>
        /// <param name="id">Genre's id, that is attached to the book</param>
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
        /// <summary>
        /// Attaching author to the book, based on author's id
        /// </summary>
        /// <param name="id">Author's id, that is attached to the book</param>
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
