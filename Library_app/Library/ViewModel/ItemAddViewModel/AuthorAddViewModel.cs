using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using System.ComponentModel;

namespace Library.ViewModel.ItemAddViewModel
{
    public class AuthorAddViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string myFirstName;
        public string MyFirstName

        {
            get { return this.myFirstName; }
            set
            {
                this.myFirstName = value;
                OnPropertyChanged("MyFirstName");
            }
        }
        protected void OnPropertyChanged(string firstName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(firstName));
            }
        }
    }
}
