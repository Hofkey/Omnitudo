using System.ComponentModel.DataAnnotations;

namespace Omnitudo.Core.Entities
{
    public class Post : BaseEntity
    {
        [Required(ErrorMessage = "Title is required."),
            MaxLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required."),
            MaxLength(250, ErrorMessage = "Description is too long.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Post date is required.")]
        public DateTime Posted { get; set; }

        [Required(ErrorMessage = "Author id is required.")]
        public Guid AuthorId { get; set; }

        public User? Author { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ICollection<Category> Categories { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public ICollection<PostFile>? Files { get; set; }
    }
}
