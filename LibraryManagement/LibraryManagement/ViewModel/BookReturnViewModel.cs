using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModel
{
    public class BookReturnViewModel : TransferViewModel
    {
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "Book id must be positive")]
        public int BookId { get; set; }
    }
}
