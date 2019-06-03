using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Library.Model;
using System.Collections.ObjectModel;

namespace Library.ViewModel
{
    /// <summary>
    /// Interaction logic for AuthorListView.xaml
    /// </summary>
    public class AuthorsListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Author> _myAuthorList = new ObservableCollection<Author>();

        public ObservableCollection<Author> MyAuthorList
        {
            get { return this._myAuthorList; }
            set
            {
                this._myAuthorList = value;
                OnPropertyChanged("MyAuthorList");
            }
        }

        public AuthorsListViewModel()
        {
            foreach (var item in Authors.AuthorsList)
            {
                MyAuthorList.Add(item);
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
