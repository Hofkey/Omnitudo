using Omnitudo.Core.Entities;

namespace Omnitudo.Core.Aggregates
{
    public class PostAggregate
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Posted { get; set; }
        public User Author { get; set; }
        public List<Category> Categories { get; set; }
        public List<PostFile> PostFiles { get; set; }
    }
}
