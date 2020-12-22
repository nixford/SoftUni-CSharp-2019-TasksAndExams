using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Models
{
    public class Card
    {
        public Card()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserCards = new HashSet<UserCard>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

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

        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}
