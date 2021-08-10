using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class BorrowedBooks
    {
        [Key]
        public int BorrowedId { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        public string UsersId { get; set; }
        [ForeignKey("UsersId")]
        public ApplicationUser User { get; set; }
        public DateTime Date { get; set; }
        public bool IsReturned { get; set; }
    }
}
