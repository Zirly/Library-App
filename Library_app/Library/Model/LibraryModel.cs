using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public static class LibraryModel
    {
        public static bool AreItemsRemoved()
        {
            if (Genres.AreRemovedItems || Authors.AreRemovedItems || Books.AreRemovedItems) return true;
            return false;
        }
        public static bool AreItemsUpdated()
        {
            if (Genres.IsUpdated || Authors.IsUpdated || Books.IsUpdated) return true;
            return false;
        }

        internal static void ChangesSaved()
        {
            Genres.AreRemovedItems = false;
            Authors.AreRemovedItems = false;
            Books.AreRemovedItems = false;
            Genres.IsUpdated = false;
            Authors.IsUpdated = false;
            Books.IsUpdated = false;
        }
    }
}
