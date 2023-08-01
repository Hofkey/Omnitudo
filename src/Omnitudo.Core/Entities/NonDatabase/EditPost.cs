using System.ComponentModel.DataAnnotations;

namespace Omnitudo.Core.Entities.NonDatabase
{
    public class EditPost
    {
        [Required(ErrorMessage = "Title is required."),
            MaxLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required."),
            MaxLength(250, ErrorMessage = "Description is too long.")]
        public string Description { get; set; } = string.Empty;

        public List<PostFile> PostFiles { get; set; }
        public List<Category> Categories { get; set; }
    }
}
