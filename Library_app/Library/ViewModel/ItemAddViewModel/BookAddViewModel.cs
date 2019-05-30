using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using System.ComponentModel;

namespace Library.ViewModel.ItemAddViewModel
{
    public class BookAddViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string myBookTitle;
        public string MyBookTitle

        {
            get { return this.myBookTitle; }
            set
            {
                this.myBookTitle = value;
                OnPropertyChanged("MyBookTitle");
            }
        }

        private string myBookYear;
        public string MyBookYear

        {
            get { return this.myBookYear; }
            set
            {
                this.myBookYear = value;
                OnPropertyChanged("MyBookYear");
            }
        }

        protected void OnPropertyChanged(string title)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(title));
            }
        }
    }
}
