namespace Omnitudo.Core.Interfaces
{
    public interface IFileService
    {
        void WriteGuidFile(string path, Guid fileId, byte[] content);

        void DeleteFile(string path);
    }
}