[assembly: WebActivator.PreApplicationStartMethod(typeof(BookShop.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(BookShop.Web.App_Start.NinjectWebCommon), "Stop")]

namespace BookShop.Web.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using BookShop.Services;
    using BookShop.Services.EntityModels;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
             kernel.Bind<DbContext>().To<BookShopEntities>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EntityRepository<>)).InRequestScope();
            kernel.Bind(typeof(IReadOnlyRepository<>)).To(typeof(EntityRepository<>));

            kernel.Bind(typeof(IUserManager)).To(typeof(UserManager));
            kernel.Bind(typeof(IBookService)).To(typeof(BookService));
        }       
    }
}
