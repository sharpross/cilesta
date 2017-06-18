namespace Cilesta.Data.Katarina
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Configuration.Interfaces;
    using Cilesta.Core;
    using Cilesta.Data.Interfaces;
    using Cilesta.Data.Katarina.Bridges;
    using Cilesta.Data.Models;

    public class Module : IModule
    {
        public string Code => "Cilesta.Data.Katarina";

        public string[] Depends => new string[1] { "Cilesta.Configuration.Katarina" };

        public void InitComponents(IWindsorContainer container)
        {
            var configuration = container.Resolve<IAppConfiguration>();

            if (configuration[Constants._Key][Constants._DatabaseType] == Constants._Key_Mysql)
            {
                container.Register(
                    Component.For<IBridge<IEntity>>()
                    .ImplementedBy<MySqlBridge<IEntity>>()
                    .Named(Constants._Key_Mysql)
                    .LifeStyle.Transient);
            }
            else
            {
                container.Register(
                    Component.For<IBridge<IEntity>>()
                    .ImplementedBy<PostrgeSqlBridge<IEntity>>()
                    .Named(Constants._Key_PostgreSQL)
                    .LifeStyle.Transient);
            }
        }

        public void Validate()
        {
            
        }
    }
}
