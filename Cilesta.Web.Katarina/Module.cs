namespace Cilesta.Web.Katarina
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Core;
    using Interfaces;
    using Implimentation;
    using System.Web.Mvc;

    public class Module : IModule
    {
        public string Code => "Cilesta.Web.Katarina";

        public string[] Depends => new string [1];

        public void InitComponents(IWindsorContainer container)
        {
            container.Register(Component.For<IControllerFactory>().ImplementedBy<WindsorControllerFactory>().LifeStyle.Transient);
            container.Register(Component.For<IFilterContainer>().ImplementedBy<FilterContainer>().LifeStyle.Transient);
            container.Register(Component.For<IRouteContainer>().ImplementedBy<RouteContainer>().LifeStyle.Transient);
            container.Register(Component.For<ICilestaValueProvider>().ImplementedBy<CilestaValueProvider>().LifeStyle.Transient);
        }

        public void Validate()
        {
            
        }
    }
}
