using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Web.Infrastructures.Filters
{
    [Flags]
    public enum AppRole
    { 
        Administrator =1,

        Users =2,

        All = Administrator|Users
    }
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {

        public AuthorizeRolesAttribute(params AppRole[] roles)
        {
            Roles = CombineRole(roles);
        }

        private static string CombineRole(params AppRole[] roles)
        {
            if (roles == null || roles.Length == 0) return string.Empty;

            AppRole result = roles.Aggregate((current, curRole) => current | curRole);
            return result.ToRoleString();
        }
    }

    
     

    public static class AppRoleExtension
    {
        public static string ToRoleString(this AppRole curRole)
        {
            List<string> roleList = new List<string>();
            if ((curRole & AppRole.Administrator) == AppRole.Administrator) roleList.Add(AppRole.Administrator.ToString());
            if ((curRole & AppRole.Users) == AppRole.Users) roleList.Add(AppRole.Users.ToString());
            return string.Join(", ",roleList);

        }
    }

}