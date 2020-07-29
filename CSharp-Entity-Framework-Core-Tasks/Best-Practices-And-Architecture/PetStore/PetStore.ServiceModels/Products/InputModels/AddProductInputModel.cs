using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PetStore.Models.Enumerations;

namespace PetStore.ServiceModels.Products.InputModels
{
    public class AddProductInputServiceModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public string productType;

        [Range(0, Double.MaxValue)]
        public decimal Price { get; set; }
    }
}
