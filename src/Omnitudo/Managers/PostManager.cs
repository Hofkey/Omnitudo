using Omnitudo.API.Helpers;
using Omnitudo.API.Mappers;
using Omnitudo.API.Models.DTO;
using Omnitudo.Core.Entities;
using Omnitudo.Core.Interfaces;
using Omnitudo.Core.Services.Interfaces;

namespace Omnitudo.API.Managers
{
    public class PostManager
    {
        private readonly string mediaPath;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IPostService postService;
        private readonly IPostFileService postFileService;
        private readonly IFileService fileService;

        public PostManager(IWebHostEnvironment webHostEnvironment,
            IPostService postService,
            IPostFileService postFileService,
            IFileService fileService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.postService = postService;
            this.postFileService = postFileService;
            this.fileService = fileService;
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

        public async Task Add(NewPostDTO newPostDTO)
        {
            var post = new NewPostDTOToPostMapper().ToSource(newPostDTO);

            await postService.Add(post);

            foreach (var file in newPostDTO.Files)
            {
                string mediaPostsPath = Path.Combine(webHostEnvironment.WebRootPath,
                    "Media", "Posts");

                await postFileService.CreateFile(new PostFile
                {
                    Description = post.Description,
                    MediaType = FileMediaTypeHelper.DetermineMediaType(file),
                    PostId = post.Id,
                    Title = post.Title,
                    Path = Path.Combine(mediaPostsPath, post.Id.ToString()),
                });

                byte[] fileContent;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }

                fileService.WriteGuidFile(mediaPostsPath, post.Id, fileContent);
            }
        }
    }
}
