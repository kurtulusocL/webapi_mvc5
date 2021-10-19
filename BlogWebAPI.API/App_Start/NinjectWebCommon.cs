[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BlogWebAPI.API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BlogWebAPI.API.App_Start.NinjectWebCommon), "Stop")]

namespace BlogWebAPI.API.App_Start
{
    using System;
    using System.Web;  
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;  
    using System.Web.Http;
    using Ninject.Web.WebApi;
    using BlogWebAPI.DataAccess.Abstract;
    using BlogWebAPI.Business.Abstract;
    using BlogWebAPI.Business.Concrete;
    using BlogWebAPI.DataAccess.Concrete.EntityFramework;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
             
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAboutDAL>().To<AboutDAL>();
            kernel.Bind<IAboutService>().To<AboutManager>();
            kernel.Bind<IBlogDAL>().To<BlogDAL>();
            kernel.Bind<IBlogService>().To<BlogManager>();
            kernel.Bind<IBlogDetailDAL>().To<BlogDetailDAL>();
            kernel.Bind<IBlogDetailService>().To<BlogDetailManager>();
            kernel.Bind<ICategoryDAL>().To<CategoryDAL>();
            kernel.Bind<ICategoryService>().To<CategoryManager>();
            kernel.Bind<IContactDAL>().To<ContactDAL>();
            kernel.Bind<IContactService>().To<ContactManager>();
            kernel.Bind<IReportDAL>().To<ReportDAL>();
            kernel.Bind<IReportService>().To<ReportManager>();
            kernel.Bind<ISocialMediaDAL>().To<SocialMediaDAL>();
            kernel.Bind<ISocialMediaService>().To<SocialMediaManager>();
            kernel.Bind<ISubcategoryDAL>().To<SubcategoryDAL>();
            kernel.Bind<ISubcategoryService>().To<SubcategoryManager>();
        }
    }
}
