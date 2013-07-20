using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShop.Services.EntityModels;

namespace BookShop.Services
{
    public interface IUserManager
    {
        List<UserStates> GetAllStates();

        List<RoleInfo> GetAllRoles();

        Users GetAllUsers();

        bool Register(string loginid, string password, string name, string address, string phone, string mail, decimal money, int userstateid, int roleinfoid);



    }
}
