using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModel
{
    public class TransferViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "First name cannot exede 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Last name cannot exede 50 characters")]
        public string LastName { get; set; }
    }
}
