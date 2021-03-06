﻿namespace Cilesta.Web.Katarina
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Optimization;
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

        public static ApplicationState State { get; set; }

        protected void Application_Start()
        {
            State = ApplicationState.Initialize;
            
            Container = new WindsorContainer();
            Container.Register(Component.For<IWindsorContainer>().Instance(Container));

            ContainerManager.Container = Container;

            var preActiation = new PreActivation(Container);
            preActiation.Init();

            var activator = new ModuleActivator();
            activator.RegisterComponents(Container);

            Logger = Container.Resolve<Logging.Interfaces.ILogger>();

            DependencyResolver.SetResolver(new WindsorDependencyResolver(Container));
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container.Kernel));

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
            
            var boundleContainers = Container.ResolveAll<IBoundleContainer>();
            foreach (var boundleContainer in boundleContainers)
            {
                boundleContainer.Init(BundleTable.Bundles);
            }
            
            ///TODO: добавить режим обслуживания
            var migrator = Container.Resolve<IMigrator>();
            
            try
            {
                var needMigrations = migrator.GetMigrations();
                
                if (needMigrations.Any())
                {
                    migrator.Migrate();
                }
            }
            catch (Exception e)
            {
                State = ApplicationState.Error;
                
                throw;
            }

            State = ApplicationState.Started;
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
