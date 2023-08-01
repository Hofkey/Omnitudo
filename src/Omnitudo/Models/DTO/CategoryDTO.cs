using System.ComponentModel.DataAnnotations;

namespace Omnitudo.API.Models.DTO
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "Identifier is required.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required."),
            MaxLength(25, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;
    }
}
