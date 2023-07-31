namespace Omnitudo.Core.Exceptions.Entities
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type entity, Guid id)
            : base(string.Format("{0} with id {1} does not exist!", entity.Name, id))
        {
        }

        public EntityNotFoundException(Type entity, string code)
            : base(string.Format("{0} with code {1} does not exist!", entity.Name, code))
        {
        }
    }
}
