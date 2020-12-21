using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Commits = new HashSet<Commit>();
            this.Repositories = new HashSet<Repository>();
        }


        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        // [MaxLength(20)] After hashing of the password, it becomes longer than 20 symbols:
        // SqlException: String or binary data would be truncated in table 'IRunes.dbo.Users', column 'Password'. Truncated value: '28618b267b8397a72ead'.
        // The statement has been terminated.
        public string Password { get; set; }

        public virtual ICollection<Repository> Repositories { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
    }
}
