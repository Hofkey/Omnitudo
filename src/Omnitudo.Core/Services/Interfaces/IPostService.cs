using Omnitudo.Core.Aggregates;
using Omnitudo.Core.Entities;
using Omnitudo.Core.Entities.NonDatabase;

namespace Omnitudo.Core.Services.Interfaces
{
    public interface IPostService
    {
        Task Add(Post post);
        Task Delete(Guid id);
        Task Edit(Guid id, EditPost editPost);
        List<PostAggregate> GetAll();
        PostAggregate GetById(Guid guid);
        List<PostAggregate> GetPostsByAuthor(Guid authorId);
        List<PostAggregate> GetPostsByCategory(Guid categoryId);
        bool PostExists(Guid guid);
    }
}