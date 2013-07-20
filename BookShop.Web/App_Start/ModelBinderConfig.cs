using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using BookShop.Web.Infrastructures.ModelBinder;

namespace BookShop.Web.App_Start
{
    public class ModelBinderConfig
    {
        public static void RegisterModelBinder(ModelBinderDictionary binders)
        {
            binders.Add(typeof(IPrincipal),new IPrincipalModelBinder());
            binders.Add(typeof(IIdentity),new IIdentityModelBinder());
        }
    }
}