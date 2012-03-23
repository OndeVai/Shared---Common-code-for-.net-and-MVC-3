namespace Shared.Domain.Service
{
    public interface IDomainService<in T>
    {
        void Save(T entity);
    }
}