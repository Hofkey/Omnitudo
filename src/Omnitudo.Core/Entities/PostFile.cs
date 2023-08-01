using Omnitudo.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Omnitudo.Core.Entities
{
    public class PostFile : BaseEntity
    {
        [Required(ErrorMessage = "File name is required."),
            MaxLength(50, ErrorMessage = "File name is too long.")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(250, ErrorMessage = "File description is too long.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Media type is required.")]
        public PostFileMediaType MediaType { get; set; }

        [Required(ErrorMessage = "Post id is required.")]
        public Guid PostId { get; set; }

        public virtual Post? Post { get; set; }
    }
}
