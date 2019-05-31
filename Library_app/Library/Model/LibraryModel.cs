using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public static class LibraryModel
    {
        public static bool IsChanged { get; set; } = false;

        public static void ChangesMade()
        {
            IsChanged = true;
        }
        public static void LibrarySaved()
        {
            IsChanged = false;
        }
    }
}
