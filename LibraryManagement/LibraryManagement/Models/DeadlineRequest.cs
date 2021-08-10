using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
