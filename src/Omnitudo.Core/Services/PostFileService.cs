using Omnitudo.Core.Entities;
using Omnitudo.Core.Exceptions.Entities;
using Omnitudo.Core.Interfaces;
using Omnitudo.Core.Services.Interfaces;

namespace Omnitudo.Core.Services
{
    public class PostFileService : IPostFileService
    {
        private readonly IFileService fileService;
        private readonly IRepository<PostFile> postFileRepository;

        public PostFileService(IFileService fileService,
            IRepository<PostFile> postFileRepository)
        {
            this.fileService = fileService;
            this.postFileRepository = postFileRepository;
        }

        public async Task CreateFile(PostFile postFile)
        {
            await postFileRepository.Create(postFile);
        }

        public async Task DeleteFile(Guid id, string rootPath)
        {
            if (postFileRepository.GetById(id) is PostFile postFile)
            {
                fileService.DeleteFile(Path.Combine(rootPath, postFile.Path));
            }
            else
            {
                throw new EntityNotFoundException(typeof(PostFile), id);
            }
        }
    }
}
