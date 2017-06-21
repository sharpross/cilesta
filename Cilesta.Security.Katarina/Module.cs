namespace Cilesta.Security.Katarina
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Core;
    using Cilesta.Security.Interfaces;
    using Cilesta.Security.Katarina.Implimentation;

    public class Module : IModule
    {
        public string Code => "Cilesta.Security.Katarina";

        public string[] Depends => new string[1];

        public void InitComponents(IWindsorContainer container)
        {
            container.Register(Component.For<IAuthService>().ImplementedBy<AuthService>().LifeStyle.Transient);
        }

        public void Validate()
        {
        }
    }
}
