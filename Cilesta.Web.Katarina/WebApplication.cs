namespace Cilesta.Web.Katarina
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Core.IoC;
    using Cilesta.Data.Interfaces;
    using Cilesta.Web.Implimentation;
    using Cilesta.Web.Interfaces;
    using Cilesta.Web.Katarina.Implimentation;

    public class WebApplication : System.Web.HttpApplication
    {
        protected static IWindsorContainer Container { get; set; }

        protected static Logging.Interfaces.ILogger Logger { get; set; }

        protected void Application_Start()
        {
            Container = new WindsorContainer();
            Container.Register(Component.For<IWindsorContainer>().Instance(Container));
            AreaRegistration.RegisterAllAreas();

            var preActiation = new PreActivation(Container);
            preActiation.Init();

            var activator = new ModuleActivator();
            activator.RegisterComponents(Container);

            Logger = Container.Resolve<Logging.Interfaces.ILogger>();

            DependencyResolver.SetResolver(new CilestaDependencyResolver(Container));

            var filterContainers = Container.ResolveAll<IFilterContainer>();
            foreach (var filterContainer in filterContainers)
            {
                filterContainer.Init(GlobalFilters.Filters);
            }

            var routeContainers = Container.ResolveAll<IRouteContainer>();
            foreach (var routeContainer in routeContainers)
            {
                routeContainer.Init(RouteTable.Routes);
            }

            var migrator = Container.Resolve<IMigrator>();
            migrator.InitMigrations();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Logger.Error(exception);
        }

        protected void Application_Stop()
        {
            Logger.Message("App stoped!");
        }

        public override void Dispose()
        {
            Container.Dispose();
            base.Dispose();
        }
    }
}
