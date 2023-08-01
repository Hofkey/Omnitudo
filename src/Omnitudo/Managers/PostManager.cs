using Omnitudo.API.Mappers;
using Omnitudo.API.Models.DTO;
using Omnitudo.Core.Services.Interfaces;

namespace Omnitudo.API.Managers
{
    public class PostManager
    {
        private readonly string mediaPath;
        private readonly IPostService postService;

        public PostManager(IPostService postService)
        {
            this.postService = postService;
        }

        public PostDTO GetPost(Guid id)
        {
            return new PostAggregatePostDTOMapper(mediaPath)
                .ToTarget(postService.GetById(id));
        }

        public List<PostDTO> GetPosts()
        {
            return new PostAggregatePostDTOMapper(mediaPath)
                .ToTarget(postService.GetAll())
                .ToList();
        }

        public List<PostDTO> GetPostsByCategory(Guid categoryId)
        {
            return new PostAggregatePostDTOMapper(mediaPath)
                .ToTarget(postService.GetPostsByCategory(categoryId))
                .ToList();
        }

        public List<PostDTO> GetPostsByAuthor(Guid authorId)
        {
            return new PostAggregatePostDTOMapper(mediaPath)
                .ToTarget(postService.GetPostsByAuthor(authorId))
                .ToList();
        }


    }
}
