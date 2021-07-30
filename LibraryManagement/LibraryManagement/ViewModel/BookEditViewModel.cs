using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModel
{
    public class BookEditViewModel
    {
        public int OldNumberOfCopies { get; set; }

        public Book CurrentBook { get; set; }
    }
}
