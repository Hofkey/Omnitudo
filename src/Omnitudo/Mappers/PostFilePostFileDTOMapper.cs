using Omnitudo.API.Models.DTO;
using Omnitudo.Core.Entities;

namespace Omnitudo.API.Mappers
{
    public class PostFilePostFileDTOMapper : Mapper<PostFile, PostFileDTO>
    {
        private readonly string path;

        public PostFilePostFileDTOMapper(string mediaPath, Guid postId)
        {
            path = $"{mediaPath}/{postId}";
        }

        public override PostFile ToSource(PostFileDTO target)
        {
            throw new NotImplementedException();
        }

        public override PostFileDTO ToTarget(PostFile source)
        {
            return new PostFileDTO
            {
                Path = $"{path}/{source.Id}.{source.Extension}",
                MediaType = source.MediaType
            };
        }
    }
}
