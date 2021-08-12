using LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModel
{
    public class BookCreateViewModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Title cannot exede 100 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Author's name cannot exede 50 characters")]
        public string Author { get; set; }
        [Required]
        public Genres Genre { get; set; }
        [Required]
        public Languages Language { get; set; }
        [Required]
        [MaxLength(512, ErrorMessage = "Author's name cannot exede 512 characters")]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public int Published { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers allowed")]
        public int Copies { get; set; }
    }
}
