namespace Omnitudo.Core.Exceptions.Entities
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type entity, Guid id)
            : base($"{entity.Name} with id {id} does not exist!")
        {
        }

        public EntityNotFoundException(Type entity, string code)
            : base($"{entity.Name} with code {code} does not exist!")
        {
        }
    }
}
