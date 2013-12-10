using EDO.Model.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace EDO.UI.WebUI.Utils
{
    public static class MembershipUtils
    {

        private static SimpleMembershipProvider _membership = (SimpleMembershipProvider)Membership.Provider;
        private static SimpleRoleProvider _roles = (SimpleRoleProvider)Roles.Provider;

        public static int GetUserIdByName(string name)
        {
            return WebSecurity.GetUserId(name);
        }

        public static int CreateUser(string login, string password, string role = "User")
        {
            login = login.ToLower();

            var user = _membership.GetUser(login, false);

            if(user == null)
            {
                _membership.CreateUserAndAccount(login, password);

                if (!_roles.GetRolesForUser(login).Contains(role))
                {
                    _roles.AddUsersToRoles(
                        new[] { login },
                        new[] { role });
                }
            }
            else
            {
                throw new Exception("Пользователь с таким логином уже существует");
            }

            return GetUserIdByName(login);
        }

        public static void Login(string login, string password)
        {
            WebSecurity.Login(login, password);
        }

        public static string[] GetRolesList()
        {
            return _roles.GetAllRoles();
        }

        public static bool IsRoleExists(string role)
        {
            return _roles.RoleExists(role);
        }

        public static void CreateRole(string role)
        {
            _roles.CreateRole(role);
        }

        public static void DeleteRole(string role)
        {
            if (!IsRoleExists(role)) return;

            if(_roles.GetUsersInRole(role).Any())
            {
                throw new Exception("Невозможно удалить НЕПУСТУЮ роль");
            }

            _roles.DeleteRole(role, true);
        }
    }
}