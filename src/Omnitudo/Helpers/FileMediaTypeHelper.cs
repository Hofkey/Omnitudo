using Omnitudo.Core.Enums;

namespace Omnitudo.API.Helpers
{
    public static class FileMediaTypeHelper
    {
        public static PostFileMediaType DetermineMediaType(IFormFile formFile)
        {
            string contentType = formFile.ContentType.ToLower();
            string extension = System.IO.Path.GetExtension(formFile.FileName).ToLower();

            if (contentType.Contains("image") || extension == ".jpg" || extension == ".png" || extension == ".gif")
                return PostFileMediaType.Image;
            else if (contentType.Contains("video") || extension == ".mp4" || extension == ".avi" || extension == ".mov")
                return PostFileMediaType.Video;
            else if (contentType.Contains("audio") || extension == ".mp3" || extension == ".wav" || extension == ".ogg")
                return PostFileMediaType.Audio;
            else if (contentType.Contains("pdf") || extension == ".pdf")
                return PostFileMediaType.Pdf;
            else
                return PostFileMediaType.Document;
        }
    }
}
