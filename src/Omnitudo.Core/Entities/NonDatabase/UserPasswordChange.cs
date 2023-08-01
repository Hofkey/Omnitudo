using System.ComponentModel.DataAnnotations;

namespace Omnitudo.Core.Entities.NonDatabase
{
    public class UserPasswordChange
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
