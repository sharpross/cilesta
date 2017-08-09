namespace Cilesta.App_Start
{
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Core;

    public class Module : IModule
    {
        public string Code => "Cilesta.App_Start";

        public string[] Depends => new string[1];

        public void InitComponents(IWindsorContainer container)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
        }

        public void Validate()
        {
            
        }
    }
}