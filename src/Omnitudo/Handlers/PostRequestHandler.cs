using Newtonsoft.Json;
using Omnitudo.API.Managers;
using Omnitudo.API.Mappers;
using Omnitudo.API.Models.DTO;

namespace Omnitudo.API.Handlers
{
    public class PostRequestHandler
    {
        private readonly string jsonContentType = "application/json";

        private readonly PostManager postManager;

        public PostRequestHandler(PostManager postManager)
        {
            this.postManager = postManager;
        }

        public async Task HandleGetPosts(HttpContext context)
        {
            context.Response.ContentType = jsonContentType;

            try
            {
                var posts = JsonConvert.SerializeObject(postManager.GetPosts());

                await context.Response.WriteAsync(posts);
            }
            catch (Exception exception)
            {
                await ReturnErrorResponse(exception, context);
            }
        }

        public async Task HandleCreatPost(HttpContext context, NewPostDTO newPostDTO)
        {
            context.Response.ContentType = jsonContentType;

            try
            {
                await postManager.Add(newPostDTO);

                context.Response.StatusCode = StatusCodes.Status201Created;

            }
            catch (Exception exception)
            {
                await ReturnErrorResponse(exception, context);
            }
        }

        public async Task ReturnErrorResponse(Exception exception, HttpContext context)
        {
            var statusCode = StatusCodes.Status500InternalServerError;
            context.Response.StatusCode = statusCode;

            var faultDto = new ExceptionFaultDTOMapper(statusCode).ToDTO(exception);
            var fault = JsonConvert.SerializeObject(faultDto);

            await context.Response.WriteAsync(fault);
        }
    }
}
