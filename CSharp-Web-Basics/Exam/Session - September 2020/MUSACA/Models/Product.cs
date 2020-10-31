using System;
using System.ComponentModel.DataAnnotations;

namespace MUSACA.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Range(typeof(decimal),"0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
