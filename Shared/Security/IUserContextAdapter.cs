namespace Shared.Security
{
    public interface IUserContextAdapter
    {
        bool IsAuthenticated { get; }
        string CurrentUserName { get; }
    }
}