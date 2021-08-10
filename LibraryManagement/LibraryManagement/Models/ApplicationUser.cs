using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
