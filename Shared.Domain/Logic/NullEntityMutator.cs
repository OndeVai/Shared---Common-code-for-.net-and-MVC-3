namespace Shared.Domain.Logic
{
    public class NullEntityMutator<T> : IEntityMutator<T> where T : IAggregateRoot
    {
        public void Mutate(T entity)
        {
            //do nothing
        }
    }
}