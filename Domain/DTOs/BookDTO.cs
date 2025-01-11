using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string ?Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string ?Author { get; set; }
        public string ?Genre { get; set; }

        [Required(ErrorMessage = "Published Year is required.")]
        [Range(1900, 2100, ErrorMessage = "Published Year should be between 1900 and 2100.")]
        public int PublishedYear { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal FinalPrice => Price - (Price * DiscountPercentage / 100);
        public decimal? Rating { get; set; }
    }
}
