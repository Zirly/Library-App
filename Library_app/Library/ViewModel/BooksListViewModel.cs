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

        private ObservableCollection<Book> _testList = new ObservableCollection<Book>();

        public ObservableCollection<Book> TestList
        {
            get { return this._testList; }
            set
            {
                this._testList = value;
                OnPropertyChanged("TestList");
            }
        }


        public BooksListViewModel()
        {
            foreach (var item in Books.BooksList)
            {
                TestList.Add(item);
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
