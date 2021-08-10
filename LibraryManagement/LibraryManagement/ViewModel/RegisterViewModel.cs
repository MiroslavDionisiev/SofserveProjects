using LibraryManagement.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "First name cannot exede 50 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Last name cannot exede 50 characters")]
        public string LastName { get; set; }

        [Required]
        public Roles Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
