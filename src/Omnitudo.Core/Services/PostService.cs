using Omnitudo.Core.Aggregates;
using Omnitudo.Core.Entities;
using Omnitudo.Core.Entities.NonDatabase;
using Omnitudo.Core.Exceptions.Entities;
using Omnitudo.Core.Interfaces;
using Omnitudo.Core.Services.Interfaces;

namespace Omnitudo.Core.Services
{
    public class PostService : IPostService
    {
        private readonly string includeAll = "Categories, Author, Files";

        private readonly IRepository<Post> postRepository;
        private readonly IRepository<PostFile> postFileRepository;
        private readonly IRepository<Category> categoryRepository;

        public PostService(IRepository<Post> postRepository,
            IRepository<PostFile> postFileRepository,
            IRepository<Category> categoryRepository)
        {
            this.postRepository = postRepository;
            this.postFileRepository = postFileRepository;
            this.categoryRepository = categoryRepository;
        }

        public bool PostExists(Guid guid) => postRepository.GetById(guid) != null;

        public PostAggregate GetById(Guid guid)
        {
            if (postRepository.Get(p => p.Id == guid,
                includeProperties: includeAll) is Post post)
            {
                return GetPostAggregate(post);
            }
            else
            {
                throw new EntityNotFoundException(typeof(Post), guid);
            }
        }

        public List<PostAggregate> GetAll()
        {
            var results = postRepository.Get(p => p.Id != Guid.Empty,
                includeProperties: includeAll);

            if (results.Any())
            {
                return results.ToList().Select(post =>
                {
                    return GetPostAggregate(post);
                }).ToList();
            }

            return new();
        }

        public List<PostAggregate> GetPostsByCategory(Guid categoryId)
        {
            if (categoryRepository.GetById(categoryId) != null)
            {
                var results = postRepository.Get(p => p.Categories.Any(c => c.Id == categoryId),
                    includeProperties: includeAll);

                if (results.Any())
                {
                    return results.ToList().Select(post =>
                    {
                        return GetPostAggregate(post);
                    }).ToList();
                }
                else
                {
                    return new();
                }
            }

            throw new EntityNotFoundException(typeof(Category), categoryId);
        }

        public List<PostAggregate> GetPostsByAuthor(Guid authorId)
        {
            var results = postRepository.Get(post => post.AuthorId == authorId,
                includeProperties: includeAll);

            if (results.Any())
            {
                return results.ToList().Select(post =>
                {
                    return GetPostAggregate(post);
                }).ToList();
            }
            else
            {
                return new();
            }
        }

        public async Task Add(Post post)
        {
            await postRepository.Create(post);
        }

        public async Task Edit(Guid id, EditPost editPost)
        {
            if (postRepository.GetById(id) is Post post)
            {
                post.Title = editPost.Title;
                post.Description = editPost.Description;
                post.Categories = editPost.Categories;
                post.Files = editPost.PostFiles;

                await postRepository.Update(post);
            }
            else
            {
                throw new EntityNotFoundException(typeof(Post), id);
            }
        }

        public async Task Delete(Guid id)
        {
            if (postRepository.Get(p => p.Id == id,
                includeProperties: includeAll) is Post post)
            {
                if (post.Files != null)
                {
                    foreach (var file in post.Files)
                    {
                        await postFileRepository.Delete(file.Id);
                    }
                }

                await postRepository.Delete(id);
            }
            else
            {
                throw new EntityNotFoundException(typeof(Post), id);
            }
        }

        private PostAggregate GetPostAggregate(Post post)
        {
            return new PostAggregate
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                Posted = post.Posted,
                Author = post.Author ?? new(),
                Categories = post.Categories?.ToList() ?? new List<Category>(),
                PostFiles = post.Files?.ToList() ?? new List<PostFile>()
            };
        }
    }
}
