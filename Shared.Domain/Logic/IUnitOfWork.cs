namespace Shared.Domain.Logic
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}