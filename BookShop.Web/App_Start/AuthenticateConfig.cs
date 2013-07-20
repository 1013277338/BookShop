using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BookShop.Web.App_Start
{
    public class AuthenticateConfig
    {
        public static void AuthenticateRequest()
        {
            if (!HttpContext.Current.Request.IsAuthenticated) return;

            if (!(HttpContext.Current.User.Identity is FormsIdentity)) return;

            FormsIdentity formsIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
            FormsAuthenticationTicket ticket = formsIdentity.Ticket;

            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(ticket.UserData)))
            {
                RoleManager roleManager = App_Start.NinjectWebCommon.Kernal.Get<RoleManager>();
                UserIdentity userIdentity = UserIdentity.LoadFromStream(stream);

                if (roleManager != null && userIdentity.IsAuthenticated)
                {
                    HttpContext.Current.User = roleManager.GetDefaultPrincipal(userIdentity);

                    // Make sure the thread current principle is same as the one we stored
                    // in the HttpContext.
                    System.Threading.Thread.CurrentPrincipal = HttpContext.Current.User;
                }
            }
        }
    }
}