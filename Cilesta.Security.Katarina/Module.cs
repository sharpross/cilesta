namespace Cilesta.Security.Katarina
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Core;
    using Cilesta.Data.Interfaces;
    using Cilesta.Domain.Katarina;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Katarina.Implimentation;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Security.Katarina.Mappings;

    public class Module : IModule
    {
        public string Code => "Cilesta.Security.Katarina";

        public string[] Depends => new string[1];

        public void InitComponents(IWindsorContainer container)
        {
            container.RegisterDomainService<User>();

            container.Register(Component.For<IAuthService>().ImplementedBy<AuthService>().LifeStyle.Transient);
            container.Register(Component.For<IUserService>().ImplementedBy<UserService>().LifeStyle.Transient);

            container.Register(Component.For<IMapping>().ImplementedBy<UserMapping>().LifeStyle.Transient);
            container.Register(Component.For<IMigration>().ImplementedBy<Migration>().LifeStyle.Transient);
        }

        public void Validate()
        {
        }
    }
}
