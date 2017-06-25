namespace Cilesta.Data.Katarina
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Configuration.Interfaces;
    using Cilesta.Data.Interfaces;
    using Cilesta.Data.Katarina.Bridges;
    using Cilesta.Data.Models;

    public static class ModuleExtension
    {
        public static void RegisterDataSource<E>(this IWindsorContainer container) 
            where E : class, IEntity
        {
            //container.Register(Component.For<S>().ImplementedBy<S>().LifeStyle.Transient);
            //container.Register(Component.For<IBridge<E>>().ImplementedBy<PostrgeSqlBridge<E>>().LifeStyle.Transient);

            var configuration = container.Resolve<IAppConfiguration>();

            if (configuration[Constants._Key][Constants._DatabaseType] == Constants._Key_Mysql)
            {
                container.Register(
                    Component.For<IBridge<E>>()
                    .ImplementedBy<MySqlBridge<E>>()
                    .LifeStyle.Transient);
            }
            else
            {
                container.Register(
                    Component.For<IBridge<E>>()
                    .ImplementedBy<PostrgeSqlBridge<E>>()
                    .LifeStyle.Transient);
            }
        }
        
    }
}
