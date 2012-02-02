namespace FreshExpress.Gain.Domain.Repositories
{
    public interface IContextLifetimeManager
    {
        bool KeepContextAlive { get; set; }
    }
}