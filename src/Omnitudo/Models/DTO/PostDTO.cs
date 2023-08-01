using System.ComponentModel.DataAnnotations;

namespace Omnitudo.API.Models.DTO
{
    public class PostDTO
    {
        [Required(ErrorMessage = "Identifier is required.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required."),
            MaxLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required."),
            MaxLength(250, ErrorMessage = "Description is too long.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Post date is required.")]
        public DateTime Posted { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public UserDTO Author { get; set; } = new();

        [Required(ErrorMessage = "Categories are required."),
            MinLength(1, ErrorMessage = "At least one category is required.")]
        public CategoryDTO[] Categories { get; set; } = Array.Empty<CategoryDTO>();

        public PostFileDTO[] Files { get; set; } = Array.Empty<PostFileDTO>();
    }
}
