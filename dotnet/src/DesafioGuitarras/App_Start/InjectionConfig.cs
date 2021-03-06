﻿[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(DesafioGuitarras.App_Start.InjectionConfig), "Initialize")]
namespace DesafioGuitarras.App_Start
{
    using DesafioGuitarras.IoC;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using SimpleInjector.Integration.WebApi;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;

    public class InjectionConfig
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //Web
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            //WebApi
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;


            Bootstrapper.RegisterContainer(container);
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}