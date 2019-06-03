using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.ViewModel
{
    /// <summary>
    /// Interaction logic for BooksListView.xaml
    /// </summary>
    public class BooksListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Book> _myBookList = new ObservableCollection<Book>();

        public ObservableCollection<Book> MyBookList
        {
            get { return this._myBookList; }
            set
            {
                this._myBookList = value;
                OnPropertyChanged("MyBookList");
            }
        }

        public BooksListViewModel()
        {
            foreach (var item in Books.BooksList)
            {
                MyBookList.Add(item);
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
