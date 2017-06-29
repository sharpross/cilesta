namespace Cilesta.Domain.Katarina
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Data.Katarina;
    using Cilesta.Data.Models;
    using Cilesta.Domain.Interfaces;
    using Cilesta.Domain.Katarina.Implimentation;

    public static class ModuleExtension
    {
        public static void RegisterDomainService<T>(this IWindsorContainer container)
            where T : class, IEntity
        {
            container.Register(Component.For<IDomainService<T>>().ImplementedBy<DomainService<T>>().LifeStyle.Transient);
            container.RegisterDataSource<T>();
        }
    }
}
