using Omnitudo.API.Models.DTO;
using Omnitudo.Core.Aggregates;

namespace Omnitudo.API.Mappers
{
    public class PostAggregatePostDTOMapper : Mapper<PostAggregate, PostDTO>
    {
        private readonly string mediaPath;

        public PostAggregatePostDTOMapper(string mediaPath)
        {
            this.mediaPath = mediaPath;
        }

        public override PostAggregate ToSource(PostDTO target)
        {
            throw new NotImplementedException();
        }

        public override PostDTO ToTarget(PostAggregate source)
        {
            return new PostDTO
            {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                Posted = source.Posted,
                Author = new UserUserDTOMapper().ToTarget(source.Author),
                Categories = new CategoryCategoryDTOMapper().ToTarget(source.Categories).ToArray(),
                Files = new PostFilePostFileDTOMapper(mediaPath, source.Id).ToTarget(source.PostFiles).ToArray()
            };
        }
    }
}
