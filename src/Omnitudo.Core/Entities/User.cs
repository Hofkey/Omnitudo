using Omnitudo.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Omnitudo.Core.Entities
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "E-mail address is required."),
            EmailAddress(ErrorMessage = "Invalid e-mail address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required."),
            MaxLength(25, ErrorMessage = "Username is too long.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.Guest;

        public virtual ICollection<Post>? Posts { get; set; }
    }
}
