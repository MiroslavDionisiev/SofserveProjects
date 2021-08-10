using LibraryManagement.Models;

namespace LibraryManagement.ViewModel
{
    public class BookEditViewModel
    {
        public int OldNumberOfCopies { get; set; }

        public Book CurrentBook { get; set; }
    }
}
