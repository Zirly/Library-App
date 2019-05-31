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
