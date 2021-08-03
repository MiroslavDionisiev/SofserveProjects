using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class DeadlineRequest
    {
        [Key]
        public int RequestId { get; set; }
        public int BorrowedId { get; set; }
        [ForeignKey("BorrowedId")]
        public BorrowedBooks Book { get; set; }

        public Status RequestStatus { get; set; }
        public bool IsDeleted { get; set; }
    }
}
