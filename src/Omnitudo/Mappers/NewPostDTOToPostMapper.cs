using Omnitudo.API.Models.DTO;
using Omnitudo.Core.Entities;

namespace Omnitudo.API.Mappers
{
    public class NewPostDTOToPostMapper : Mapper<Post, NewPostDTO>
    {
        public override Post ToSource(NewPostDTO target)
        {
            return new Post
            {
                Title = target.Title,
                Description = target.Description,
                Posted = DateTime.Now,
                AuthorId = target.AuthorId
            };
        }

        public override NewPostDTO ToTarget(Post source)
        {
            throw new NotImplementedException();
        }
    }
}
