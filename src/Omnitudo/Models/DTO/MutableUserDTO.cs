using Omnitudo.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Omnitudo.API.Models.DTO
{
    public class MutableUserDTO
    {
        [Required(ErrorMessage = "E-mail address is required."),
            EmailAddress(ErrorMessage = "Invalid e-mail address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required."),
            MaxLength(50, ErrorMessage = "Username is too long.")]
        public string UserName { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.Guest;
    }
}
