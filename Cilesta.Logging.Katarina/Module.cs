namespace Cilesta.Logging.Katarina
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Core;
    using Cilesta.Logging.Katarina.Implimentation;

    public class Module : IModule
    {
        public string Code => "Cilesta.Logging.Katarina";

        public string[] Depends => new string[1];

        public void InitComponents(IWindsorContainer container)
        {
            container.Register(
                Component.For<Interfaces.ILogger>()
                .ImplementedBy<EmptyLogger>()
                .Named(Constants.Logger_Empty)
                .LifeStyle.Singleton);

            container.Register(
                Component.For<Interfaces.ILogger>()
                .ImplementedBy<TextLogger>()
                .Named(Constants.Logger_Text)
                .LifeStyle.Singleton);
        }

        public void Validate()
        {
        }
    }
}
