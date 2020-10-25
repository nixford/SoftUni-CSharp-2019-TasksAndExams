using Andreys.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Andreys.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        // [MinLength(4)]
        // [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        // [MaxLength(10)]
        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
