namespace Cilesta.Web
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Utils.Common;
    using Cilesta.Web.Interfaces;

    public static class WindsorExtension
    {
        public static void RegisterController (this IWindsorContainer container, Type controller)
        {
            var name = WebUtils.GetControllerName(controller);

            container.Register(
                Component.For<ICilestaController>()
                .Named(name)
                .ImplementedBy(controller)
                .LifeStyle.Transient);
        }
    }
}
