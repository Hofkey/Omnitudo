using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Omnitudo.API.Exceptions
{
    public class ModelStateErrorException : Exception
    {
        public string[] Errors { get; }

        public ModelStateErrorException(ModelStateDictionary modelState)
        {
            Errors = GetModelStateErrors(modelState);
        }

        public ModelStateErrorException(ModelStateDictionary modelState, string message)
            : base(message)
        {
            Errors = GetModelStateErrors(modelState);
        }

        public ModelStateErrorException(ModelStateDictionary modelState, string message, Exception innerException)
            : base(message, innerException)
        {
            Errors = GetModelStateErrors(modelState);
        }

        public string[] GetModelStateErrors(ModelStateDictionary modelState)
        {
            return modelState.Values
                .SelectMany(entry => entry.Errors)
                .Select(error => error.ErrorMessage)
                .ToArray();
        }
    }
}
