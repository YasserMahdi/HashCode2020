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
        public string NumberOfBooks { get; set; } // field
        public string SignUp { get; set; }
        public string BookaPerDay { get; set; }
        public List<BookInLib> BookIndexes { get; set; }
    }
}
