namespace Cilesta.Data.Katarina
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Configuration.Interfaces;
    using Cilesta.Core;
    using Cilesta.Data.Interfaces;
    using Cilesta.Data.Katarina.Bridges;
    using Cilesta.Data.Katarina.Implimentation;
    using Cilesta.Data.Models;

    public class Module : IModule
    {
        public string Code => "Cilesta.Data.Katarina";

        public string[] Depends => new string[1] { "Cilesta.Configuration.Katarina" };

        public void InitComponents(IWindsorContainer container)
        {
            var configuration = container.Resolve<IAppConfiguration>();

            if (configuration[Constants.Key][Constants.Type] == Constants.Key_Mysql)
            {
                container.Register(
                    Component.For<IBridge<IEntity>>()
                    .ImplementedBy<MySqlBridge<IEntity>>()
                    .LifeStyle.PerWebRequest);
            }
            else
            {
                container.Register(
                    Component.For<IBridge<IEntity>>()
                    .ImplementedBy<PostrgeSqlBridge<IEntity>>()
                    .LifeStyle.PerWebRequest);
            }

            container.Register(Component.For<IMigrator>().ImplementedBy<Migrator>().LifeStyle.Transient);
        }

        public void Validate()
        {
            
        }
    }
}
