namespace Shared.Domain.Security.Services
{
    public interface IRoleService
    {
        void AddUserToRole(string username, string roleName);
        string[] GetRolesForUser(string username);
        void RemoveUserFromRoles(string username, string[] roleNames);
        bool IsUserInRole(string username, string roleName);
    }
}