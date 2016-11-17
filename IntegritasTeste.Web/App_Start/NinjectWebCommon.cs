using IntegritasTeste.Application;
using IntegritasTeste.Application.Application;
using IntegritasTeste.DataContext.Repositories;
using IntegritasTeste.Domain.Interface.Aplications;
using IntegritasTeste.Domain.Interface.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IntegritasTeste.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(IntegritasTeste.Web.App_Start.NinjectWebCommon), "Stop")]

namespace IntegritasTeste.Web.App_Start
{
    using System;
    using System.Web;

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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            kernel.Bind(typeof(IBaseApplication<>)).To(typeof(BaseApplication<>));
            kernel.Bind<ICustomerApplication>().To<CustomerApplication>();
            kernel.Bind<ICategoryApplication>().To<CategoryApplication>();
            kernel.Bind<IProductApplication>().To<ProductApplication>();
            kernel.Bind<ILoggerApplication>().To<LoggerApplication>();



            kernel.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<ILoggerRepository>().To<LoggerRepository>();

            IntegritasTeste.Domain.Common.Extensions.Init(kernel);
            
       

        }        
    }
}
