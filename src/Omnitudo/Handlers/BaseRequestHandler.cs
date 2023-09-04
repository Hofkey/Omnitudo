using Newtonsoft.Json;
using Omnitudo.API.Mappers;

namespace Omnitudo.API.Handlers
{
    public class BaseRequestHandler
    {
        /// <summary>
        /// Returns an error response.
        /// Also maps an exception to a FaultDTO.
        /// </summary>
        /// <param name="exception">The thrown exception.</param>
        /// <param name="context">The http context.</param>
        /// <returns>An error response with a FaultDTO.</returns>
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