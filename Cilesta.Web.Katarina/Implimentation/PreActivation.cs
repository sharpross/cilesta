namespace Cilesta.Web.Katarina.Implimentation
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Configuration.Interfaces;
    using Cilesta.Configuration.Katarina.Implimentation;
    using Cilesta.Logging.Katarina.Implimentation;

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

            var configuration = Container.Resolve<IAppConfiguration>();
            var loggerType = configuration[Logging.Constants.Key][Logging.Constants.Type];

            switch (loggerType)
            {
                case Logging.Constants.Logger_Empty:
                    Container.Register(
                        Component.For<Logging.Interfaces.ILogger>()
                        .ImplementedBy<EmptyLogger>()
                        .LifeStyle.Singleton);
                    break;
                default:
                    Container.Register(
                        Component.For<Logging.Interfaces.ILogger>()
                        .ImplementedBy<TextLogger>()
                        .LifeStyle.Singleton);
                    break;
            }
            
            var logger = Container.Resolve<Logging.Interfaces.ILogger>();
            logger.Init();
        }
    }
}
