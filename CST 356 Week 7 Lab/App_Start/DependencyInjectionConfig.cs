using CST_356_Week_7_Lab.Data;
using CST_356_Week_7_Lab.Data.Repositories;
using CST_356_Week_7_Lab.Models;
using CST_356_Week_7_Lab.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace CST_356_Week_7_Lab.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            //container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IClassRepository, ClassRepository>(Lifestyle.Scoped);
            //container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IClassService, ClassService>(Lifestyle.Scoped);
            container.Register<DatabaseContext, DatabaseContext>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            


            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
        new SimpleInjectorWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}