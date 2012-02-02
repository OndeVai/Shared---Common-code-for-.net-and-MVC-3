namespace Shared.Domain.Infrastructure
{
    public interface IUnitOfWork
    {
        // ReSharper disable UnusedMember.Global
        void SaveChanges();
        // ReSharper restore UnusedMember.Global
    }
}