namespace Shared.Domain.Logic
{
    public interface IEntityMutator<in T> where T : IAggregateRoot
    {
        void Mutate(T entity);
    }
}