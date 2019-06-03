using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using System.ComponentModel;

namespace Library.ViewModel.ItemAddViewModel
{
    /// <summary>
    /// Interaction logic for BookAddView.xaml
    /// </summary>
    public class BookAddViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Book myBook = new Book();
        public Book MyBook
        {
            get { return this.myBook; }
            set
            {
                this.myBook = value;
                OnPropertyChanged("MyBook");
            }
        }
        /// <summary>
        /// Raises an event, when property is changed
        /// </summary>
        /// <param name="name">changed property</param>
        protected void OnPropertyChanged(string text)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(text));
            }
        }


    }
}
