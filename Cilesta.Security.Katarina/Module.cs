namespace Cilesta.Security.Katarina
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Core;
    using Cilesta.Data.Interfaces;
    using Cilesta.Security.Interfaces;
    using Cilesta.Security.Katarina.Implimentation;
    using Cilesta.Security.Katarina.Mappings;

    public class Module : IModule
    {
        public string Code => "Cilesta.Security.Katarina";

        public string[] Depends => new string[1];

        public void InitComponents(IWindsorContainer container)
        {
            container.Register(Component.For<IAuthService>().ImplementedBy<AuthService>().LifeStyle.Transient);

            container.Register(Component.For<IMapping>().ImplementedBy<UserMapping>().LifeStyle.Transient);
        }

        public void Validate()
        {
        }
    }
}
