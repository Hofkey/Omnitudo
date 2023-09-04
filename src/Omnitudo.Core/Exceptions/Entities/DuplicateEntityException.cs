namespace Omnitudo.Core.Exceptions.Entities
{
    public class DuplicateEntityException : Exception
    {
        public DuplicateEntityException(Type type, string property, string value)
            : base($"{type.Name} with {property} with the value of {value}, already exists!")
        {
        }
    }
}
