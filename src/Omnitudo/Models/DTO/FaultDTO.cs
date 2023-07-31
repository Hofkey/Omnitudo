namespace Omnitudo.API.Models.DTO
{
    public class FaultDTO
    {
        public int StatusCode { get; set; }

        public string ExceptionMessage { get; set; } = string.Empty;

        public string[]? ExceptionInnerMessages { get; set; }
    }
}
