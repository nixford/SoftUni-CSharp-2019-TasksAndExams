using System.ComponentModel.DataAnnotations;
using System;

namespace MUSACA.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set; }
    }
}
