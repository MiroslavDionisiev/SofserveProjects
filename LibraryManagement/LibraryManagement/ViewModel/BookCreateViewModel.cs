using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModel
{
    public class BookCreateViewModel
    {//
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
        public int Published { get; set; }
        [Required]
        public int Copies { get; set; }
    }
}
