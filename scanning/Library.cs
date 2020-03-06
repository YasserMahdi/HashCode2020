using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scanning
{
    class Library
    {
        public int index { get; set; }
        public int NumberOfBooks { get; set; } // field
        public int SignUp { get; set; }
        public int BookaPerDay { get; set; }
        public List<BookInLib> BookIndexes { get; set; }
    }
}
