namespace Shared.Domain.Repository.Legacy
{
    public interface IContextLifetimeManager
    {
        bool KeepContextAlive { get; set; }
    }
}