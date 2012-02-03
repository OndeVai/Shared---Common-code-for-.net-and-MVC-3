namespace Shared.Domain.Infrastructure
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}