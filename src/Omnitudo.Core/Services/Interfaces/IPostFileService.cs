using Omnitudo.Core.Entities;

namespace Omnitudo.Core.Services.Interfaces
{
    public interface IPostFileService
    {
        Task CreateFile(PostFile postFile);
        Task DeleteFile(Guid id, string rootPath);
    }
}