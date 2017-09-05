namespace Cilesta.Web.Katarina.Implimentation
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Castle.MicroKernel;
    using Cilesta.Utils.Common;
    using Cilesta.Web.Interfaces;

    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new NotFoundException("Контролер не найден.");
            }

            var name = WebUtils.GetControllerName(controllerType);

            var controller = this._kernel.Resolve<ICilestaController>(name);

            if (controller == null)
            {
                throw new NotFoundException("Контролер с именем \"" + name + "\" не найден.");
            }

            return controller as IController;
        }
    }
}
