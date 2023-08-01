using System.ComponentModel.DataAnnotations;

namespace Omnitudo.API.Models.DTO
{
    public class NewPostDTO
    {
        [Required(ErrorMessage = "Identifier is required.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required."),
            MaxLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required."),
            MaxLength(250, ErrorMessage = "Description is too long.")]
        public string Description { get; set; } = string.Empty;

        public DateTime Posted { get; } = DateTime.Now;

        [Required(ErrorMessage = "Author identifier is required.")]
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "Categories are required."),
            MinLength(1, ErrorMessage = "At least one category is required.")]
        public List<CategoryDTO> Categories { get; set; } = new();

        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}
