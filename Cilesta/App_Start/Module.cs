namespace Cilesta.App_Start
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Controllers;
    using Cilesta.Core;
    using Cilesta.Web;
    using Cilesta.Web.Interfaces;

    public class Module : IModule
    {
        public string Code
        {
            get
            {
                return "Cilesta.App_Start";
            }
        }

        public string[] Depends => new string[1];

        public void InitComponents(IWindsorContainer container)
        {
            container.Register(Component.For<IRouteContainer>().ImplementedBy<RouteContainer>().LifeStyle.Transient);

            container.RegisterController(typeof(HomeController));
            container.RegisterController(typeof(UserController));
            container.RegisterController(typeof(ErrorController));
            container.RegisterController(typeof(LoginController));
        }

        public void Validate()
        {
            
        }
    }
}