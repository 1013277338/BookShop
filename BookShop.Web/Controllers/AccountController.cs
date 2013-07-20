using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using BookShop.Services;
using BookShop.Web.Models;
using Ninject;

namespace BookShop.WebApp.Controllers
{
    public class AccountController : Controller
    {
        [Inject]
        UserManager userService { get; set; }

        public AccountController(UserManager UserService)
        {
            userService = UserService;
        }



        [HttpGet]
        public ActionResult LogOn()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(UserView user)
        {
            var result = userService.GetUserById(user.loginId);
            if (result != null)
            {

                TimeSpan cookieExpireTimeSpan = new TimeSpan(0, 20, 0);
                //从配置文件中读取设置的cookie过期时间
                AuthenticationSection authenticationSection = WebConfigurationManager.GetWebApplicationSection("system.web/authentication") as AuthenticationSection;
                if (authenticationSection != null && authenticationSection.Forms != null)
                {
                    FormsAuthenticationConfiguration formsAuthentication = authenticationSection.Forms;
                    cookieExpireTimeSpan = formsAuthentication.Timeout;
                }

                //生成forms验证票据
                FormsAuthenticationTicket authenticationTicket = new FormsAuthenticationTicket(1,
                    user.loginId, DateTime.Now, DateTime.Now.Add(cookieExpireTimeSpan),
                    false, "", FormsAuthentication.FormsCookiePath);

                string encryptedCookieContent = FormsAuthentication.Encrypt(authenticationTicket);
                //添加Cookie
                HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedCookieContent);
                // authenticationCookie.Secure = FormsAuthentication.RequireSSL;
                Response.Cookies.Add(authenticationCookie);

                return RedirectToAction("List", "Home");
            }
            else
            {
                return View();
            }

        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logon", "Account");
        }

        [HttpGet]
        public ActionResult Register()
        {
            RegisterUser user = new RegisterUser();
           
            ViewBag.userStates = GetUserStates();
            ViewBag.userRoles = GetUserRoles();
            return View(user);
        }

        public List<SelectListItem> GetUserRoles()
        {
            var data = userService.GetAllRoles();
            return data.Select(role => new SelectListItem()
            {
                Text = role.rolename,
                Value = role.id.ToString()
            }).ToList();
        }
        public List<SelectListItem> GetUserStates()
        {
            var data = userService.GetAllStates();
            return data.Select(state => new SelectListItem() {
                Text = state.name,
                Value = state.id.ToString()
            }).ToList();
        }

        [HttpPost]
        public ActionResult Register(RegisterUser user)
        {
            object message=new object();
            try
            {
                var data = userService.Register(user.loginId, user.loginPwd, user.name, user.address, user.phone, user.mail, user.money, 0, 0);
                if (data)
                {
                    message = new { message = "Ok" };
                }
                else
                {
                    message = new { Message = "False" };
                }
            }
            catch (Exception )
            {
                
                
            }

            return Json(message);
           
        }

    }
}
