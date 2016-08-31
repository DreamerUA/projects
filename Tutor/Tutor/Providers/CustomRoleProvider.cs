using System;
using System.Web.Security;
using Tutor.Core.Entities;
using Tutor.Data.Repository;

namespace Tutor.Web.Providers
{
    /// <summary>
    /// Role provider
    /// </summary>
    public class CustomRoleProvider : RoleProvider
    {
        RoleRepository roleRepo;
        UserRepository userRepo;
        /// <summary>
        /// Constructor
        /// </summary>
        public CustomRoleProvider()
        {
            roleRepo = new RoleRepository();
            userRepo = new UserRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLogin"> User login</param>
        /// <returns>
        /// Array of roles
        /// </returns>
        public override string[] GetRolesForUser(string userLogin)
        {
            string[] role = new string[] { };

            User user = userRepo.GetUserByLogin(userLogin);
            if (user != null)
            {
                Role userRole = roleRepo.GetRoleById(user.RoleId);
                if (userRole != null)
                    role = new string[] { userRole.Name };
            }
            return role;
        }
        /// <summary>
        /// Create role
        /// </summary>
        /// <param name="roleName">
        /// Name of role
        /// </param>
        public override void CreateRole(string roleName)
        {
            Role newRole = new Role() { Name = roleName };
            roleRepo.Create(newRole);
            roleRepo.Save();
        }
        /// <summary>
        /// Check is user in role
        /// </summary>
        /// <param name="userLogin">
        /// Unique user name
        /// </param>
        /// <param name="roleName">
        /// Name of role
        /// </param>
        /// <returns>
        /// bool
        /// </returns>
        public override bool IsUserInRole(string userLogin, string roleName)
        {
            bool outputResult = false;
            User user = userRepo.GetUserByLogin(userLogin);
            if (user != null)
            {
                Role userRole = roleRepo.GetRoleById(user.RoleId);
                if (userRole != null && userRole.Name == roleName)
                    outputResult = true;
            }

            return outputResult;
        }
        public override void AddUsersToRoles(string[] userLogins, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string userLoginToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] userLogins, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}