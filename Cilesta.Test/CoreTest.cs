namespace Cilesta.Test
{
    using System.Linq;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Data.Interfaces;
    using Cilesta.Web.Implimentation;
    using Cilesta.Web.Katarina.Implimentation;

    public class CoreTest
    {
        protected static IWindsorContainer Container { get; set; }

        public CoreTest()
        {
            Container = new WindsorContainer();
            Container.Register(Component.For<IWindsorContainer>().Instance(Container));

            var preActiation = new PreActivation(Container);
            preActiation.Init();

            var activator = new ModuleActivator();
            activator.RegisterComponents(Container);

            var migrator = Container.Resolve<IMigrator>();
            var needMigrations = migrator.GetMigrations();
            
            if (needMigrations.Any())
            {
                migrator.Migrate();
            }
            else
            {

            }
        }
    }
}
