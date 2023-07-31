using Omnitudo.API.Exceptions;
using Omnitudo.API.Models.DTO;
using System.Net;

namespace Omnitudo.API.Mappers.Exceptions
{
    public class ModelStateErrorExceptionFaultDTOMapper
    {
        private readonly HttpStatusCode statusCode;

        public ModelStateErrorExceptionFaultDTOMapper(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
        }

        public FaultDTO ToDTO(ModelStateErrorException modelStateErrorException)
        {
            return new FaultDTO
            {
                ExceptionMessage = modelStateErrorException.Message ?? "",
                StatusCode = (int)statusCode,
                ExceptionInnerMessages = modelStateErrorException.Errors
            };
        }
    }
}
