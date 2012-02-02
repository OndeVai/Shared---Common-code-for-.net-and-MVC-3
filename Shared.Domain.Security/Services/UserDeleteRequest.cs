namespace Shared.Domain.Security.Services
{
    public class UserDeleteRequest
    {
        public UserDeleteRequest(string username, bool deleteAllRelatedData)
        {
            UserName = username;
            DeleteAllRelatedData = deleteAllRelatedData;
        }

        public string UserName { get; private set; }
        public bool DeleteAllRelatedData { get; private set; }
    }
}