using Omnitudo.Core.Interfaces;

namespace Omnitudo.Infrastructuur.Services
{
    public class FileService : IFileService
    {
        public void WriteGuidFile(string path, Guid fileId, byte[] content)
        {
            File.WriteAllBytes($"{path}/{fileId}", content);
        }
    }
}
