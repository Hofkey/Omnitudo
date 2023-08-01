using Omnitudo.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Omnitudo.API.Models.DTO
{
    public class PostFileDTO
    {
        [Required(ErrorMessage = "Path is required.")]
        public string Path { get; set; } = string.Empty;

        [Required(ErrorMessage = "Media type is required.")]
        public PostFileMediaType MediaType { get; set; }
    }
}
