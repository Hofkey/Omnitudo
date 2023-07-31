namespace Omnitudo.Core.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime Posted { get; set; }

        public Guid AuthorId { get; set; }

        public User? Author { get; set; }

        public ICollection<Category>? Categories { get; set; }
    }
}
