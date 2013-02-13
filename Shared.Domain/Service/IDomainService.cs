namespace Shared.Domain.Service
{
    public interface IDomainService<in T>
    {
        void ValidateAndSave(T entity);
    }
}