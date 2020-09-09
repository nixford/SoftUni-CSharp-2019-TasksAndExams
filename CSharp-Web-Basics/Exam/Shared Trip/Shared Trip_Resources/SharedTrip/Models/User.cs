using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class User
    {       
        public User()
        {
            this.UserTrips = new HashSet<UserTrip>();
        }


        [Key]
        public string Id { get; set; }

        // [MinLength(5)]
        // [MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        // [MinLength(6)]
        // [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        public virtual ICollection<UserTrip> UserTrips { get; set; }
    }
}
