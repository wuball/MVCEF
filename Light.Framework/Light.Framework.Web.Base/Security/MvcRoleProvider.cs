using System;
using System.Web;
using System.Web.Security;

namespace Light.Framework.Web.Base.Security
{
    public class MvcRoleProvider : RoleProvider
    {
        #region Overrides of RoleProvider

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (HttpContext.Current.User == null) return null;
            if (!HttpContext.Current.User.Identity.IsAuthenticated) return null;
            var identity = HttpContext.Current.User.Identity as FormsIdentity;
            if (identity == null) return null;

            var id = identity;
            var ticket = id.Ticket;
            var userData = ticket.UserData;
            var roles = userData.Split(',');
            return roles;
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion
    }
}