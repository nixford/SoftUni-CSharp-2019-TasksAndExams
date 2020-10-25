using System.ComponentModel.DataAnnotations;

namespace SUS.MvcFramework
{
    public class IdentityUser<T>
    {
        public T Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        // [MaxLength(20)] After hashing of the password, it becomes longer than 20 symbols:
        // SqlException: String or binary data would be truncated in table 'IRunes.dbo.Users', column 'Password'. Truncated value: '28618b267b8397a72ead'.
        // The statement has been terminated.
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }        

        public IdentityRole Role { get; set; }
    }
}
