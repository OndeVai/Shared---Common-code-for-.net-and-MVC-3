#region

using System.Web.Security;

#endregion

namespace Shared.Infrastructure.Security.Services.Impl
{
    public class AspNetRoleService : IRoleService
    {
        #region Implementation of IRoleService

        public void AddUserToRole(string username, string roleName)
        {
            Roles.AddUserToRole(username, roleName);
        }

        public string[] GetRolesForUser(string username)
        {
            return Roles.GetRolesForUser(username);
        }

        public void RemoveUserFromRoles(string username, string[] roleNames)
        {
            Roles.RemoveUserFromRoles(username, roleNames);
        }

        public bool IsUserInRole(string username, string roleName)
        {
            return Roles.IsUserInRole(username, roleName);
        }

        #endregion
    }
}