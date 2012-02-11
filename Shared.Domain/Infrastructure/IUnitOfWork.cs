namespace Shared.Domain.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}