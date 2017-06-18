namespace Cilesta.Core
{
    using System;
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Utils.Common;

    public static class WindsorExtentions
    {
        public static void RegisterController<T>(this IWindsorContainer container, Type controller) where T : IController
        {
            var name = WebUtils.GetControllerName(controller);

            container.Register(
                Component.For<IController>()
                .Named(name)
                .ImplementedBy(controller)
                .LifeStyle.Transient);
        }
    }
}
