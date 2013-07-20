using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Web.Infrastructures.ModelBinder
{
    /// <summary>
    /// Defines the methods that are required to auto-bind <see cref="IIdentity"/>.
    /// </summary>
    public class IIdentityModelBinder : IModelBinder
    {
        /// <summary>
        /// Binds the <see cref="IIdentity"/> from <see cref="HttpContext.User"/>.
        /// </summary>
        /// <returns>The reference of <see cref="IIdentity"/>.</returns>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="bindingContext">The binding context.</param>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Contract.Requires(controllerContext != null, "controllerContext cannot be null.");

            return controllerContext.HttpContext.User.Identity;
        }
    }
}