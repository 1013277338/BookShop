using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShop.Services.EntityModels;


namespace BookShop.Services
{
   public class UserManager
    {
      


       public IRepository<Users> userRepository { get; set; }

       public IRepository<RoleInfo> roleInfoReposiroty { get; set; }

       public IRepository<UserStates> userStatesRepository { get; set; }


       public UserManager(IRepository<Users> UserRepository, IRepository<RoleInfo> RoleInfoRepository,IRepository<UserStates> UserStatesRepository)
       {
           userRepository = UserRepository;
           roleInfoReposiroty = RoleInfoRepository;
           userStatesRepository = UserStatesRepository;
       }
       public UserManager() { }

       public List<UserStates> GetAllStates()
       {
          // return db.UserStates.Where(s=>s.id>0).ToList();
           return userStatesRepository.Table.Where(s=>s.id>0).ToList();

       }
       public List<RoleInfo> GetAllRoles()
       {
           return roleInfoReposiroty.Table.ToList();
           //return db.RoleInfo.ToList();

           
       }

       public Users GetAllUsers()
       {
          //return db.Users.FirstOrDefault(u => u.id == 1);
           return userRepository.Find(2);
       }
       public Users GetUserById(string id)
       {
           return userRepository.Table.FirstOrDefault(u=>u.loginid==id);
       }

       public Users GetUserByName(string name)
       {
           return userRepository.Table.FirstOrDefault(u=>u.name==name);
       }

       public bool Register(string loginid,string password,string name,string address,string phone,string mail,decimal money,int userstateid,int roleinfoid)
       {
           try
           {
               bool b = false;

               Users user = new Users();
               
               user.address = address;
               user.loginid = loginid;
               user.loginpwd = password;
               user.mail = mail;
               user.money = money;
               user.name = name;
               user.phone = phone;
               user.userstateid = 1;
               user.roleinfoid = 1;

               userRepository.Add(user);
               userRepository.Save();
               //db.Users.Add(user);
               //db.SaveChanges();
               return b;
           }
           catch (Exception ex)
           {
               
               throw;
           }
           
       }
    }
}
