using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Relation
    {
        public int RelationId { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}
