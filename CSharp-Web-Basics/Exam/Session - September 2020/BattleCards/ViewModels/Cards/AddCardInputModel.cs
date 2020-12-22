using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.ViewModels.Cards
{
    public class AddCardInputModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Keyword { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Attack { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Health { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
