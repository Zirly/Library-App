using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? YearBirth { get; set; }
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
    }
}
