using Omnitudo.API.Exceptions;
using Omnitudo.API.Models.DTO;

namespace Omnitudo.API.Mappers
{
    public class ExceptionFaultDTOMapper
    {
        private readonly int statusCode;

        public ExceptionFaultDTOMapper(int statusCode)
        {
            this.statusCode = statusCode;
        }

        public FaultDTO ToDTO(Exception exception)
        {
            if (exception is ModelStateErrorException modelStateErrorException)
            {
                return new FaultDTO
                {
                    ExceptionMessage = modelStateErrorException.Message ?? "",
                    StatusCode = statusCode,
                    ExceptionInnerMessages = modelStateErrorException.Errors
                };
            }

            return new FaultDTO
            {
                ExceptionMessage = exception.Message ?? "",
                StatusCode = statusCode,
                ExceptionInnerMessages = new[] { exception.InnerException?.Message ?? string.Empty }
            };
        }
    }
}
