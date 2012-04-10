[assembly: WebActivator.PreApplicationStartMethod(typeof(MvcNinjectCars.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(MvcNinjectCars.App_Start.NinjectWebCommon), "Stop")]

namespace MvcNinjectCars.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using MvcNinjectCars.Mappers;
    using MvcNinjectCars.Repositories;
    using MvcNinjectCars.Services;
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
            /*
             * This is the only part of this class that needs to be modified. 
             * Here we define the relationship between the injection object asked for and what Ninject actually looks for,
             *      so whenever the app encounters ICarRepository, it automagically creates a new instance of CarRepository.
             * Good article: http://www.kevinrohrbaugh.com/blog/2009/8/7/using-ninject-2-with-aspnet-mvc.html
             */
            kernel.Bind<ICarRepository>().To<CarRepository>();
            kernel.Bind<ICarService>().To<CarService>();
            kernel.Bind<IMapper>().To<CarMapper>();
        }        
    }
}
