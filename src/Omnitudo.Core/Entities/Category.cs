using System.ComponentModel.DataAnnotations;

namespace Omnitudo.Core.Entities
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Title is required."),
            MaxLength(25, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;

        public virtual ICollection<Post>? Posts { get; set; }
    }
}
