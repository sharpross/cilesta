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
        public static void RegisterDataSource<T>(this IWindsorContainer container) 
            where T : class, IEntity
        {
            var configuration = container.Resolve<IAppConfiguration>();

            if (configuration[Constants.Key][Constants.Type] == Constants.Key_Mysql)
            {
                container.Register(
                    Component.For<IBridge<T>>()
                    .ImplementedBy<MySqlBridge<T>>()
                    .LifeStyle.Transient);
            }
            else
            {
                container.Register(
                    Component.For<IBridge<T>>()
                    .ImplementedBy<PostrgeSqlBridge<T>>()
                    .LifeStyle.Transient);
            }
        }
    }
}
