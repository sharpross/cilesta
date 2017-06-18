namespace Cilesta.Web.Katarina.Implimentation
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Configuration.Interfaces;
    using Cilesta.Configuration.Katarina.Implimentation;

    public class PreActivation
    {
        private IWindsorContainer Container { get; set; }

        private IAppConfiguration Configuration { get; set; }

        public PreActivation(IWindsorContainer container)
        {
            this.Container = container;
        }

        public void Init()
        {
            InitConfiguration();
        }

        private void InitConfiguration()
        {
            Container.Register(Component.For<IAppConfiguration>().ImplementedBy<AppConfiguration>().LifeStyle.Singleton);
            this.Container.Resolve<IAppConfiguration>();
        }
    }
}
