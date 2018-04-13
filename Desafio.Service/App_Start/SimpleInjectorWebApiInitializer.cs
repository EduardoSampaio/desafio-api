//[assembly: WebActivator.PostApplicationStartMethod(typeof(Desafio.Service.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Desafio.Service.App_Start
{
    using Desafio.Infra.Crosscutting.IOC;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using System.Web.Http;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static Container Initialize(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(config);

            container.Verify();

            config.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
            return container;
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.Register(container);
        }
    }
}