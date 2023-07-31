namespace Omnitudo.Core.Exceptions.Entities
{
    public class DuplicateEntityException : Exception
    {
        public DuplicateEntityException(string entity, string property, string value)
            : base(string.Format("{0} with {1} with the value of {2}, already exists!", entity, property, value))
        {
        }
    }
}
