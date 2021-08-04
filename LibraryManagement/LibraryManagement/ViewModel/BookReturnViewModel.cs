using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModel
{
    public class BookReturnViewModel : TransferViewModel
    {
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "Book id must be positive")]
        public int BookId { get; set; }
    }
}
