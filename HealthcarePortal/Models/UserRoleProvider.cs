using HealthcarePortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HealthcarePortal.Models
{
    public class UserRoleProvider : RoleProvider
    {
        private readonly HealthcarePortalContext _db = new HealthcarePortalContext();

        public override string ApplicationName 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            var users = _db.Users.Include(x => x.Roles).Where(x => usernames.Contains(x.Email)).ToList();
            var roles = _db.Roles.Where(x => roleNames.Contains(x.RoleName)).ToList();
            foreach (var user in users)
            {
                foreach (var role in roles)
                {
                    user.Roles.Add(role);
                }
            }
            _db.SaveChanges();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return _db.Roles.Select(x => x.RoleName).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            var user = _db.Users.Include(x => x.Roles).FirstOrDefault(x => x.Email == username);
            return user.Roles.Select(x => x.RoleName).ToArray();  
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var roles = _db.Roles.Include(x => x.Users).FirstOrDefault(x => x.RoleName == roleName);
            return roles.Users.Select(x => x.Email).ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = _db.Users.Include(x => x.Roles).FirstOrDefault(x => x.Email == username);
            return user.Roles.Any(x => x.RoleName == roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            return _db.Roles.Any(x => x.RoleName == roleName);
        }
    }
}