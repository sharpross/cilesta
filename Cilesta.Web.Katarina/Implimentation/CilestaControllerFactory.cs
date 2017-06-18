﻿namespace Cilesta.Web.Katarina.Implimentation
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.SessionState;
    using Castle.MicroKernel;
    using Castle.Windsor;

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
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            var controller = (Controller)_kernel.Resolve(controllerType);
            return controller;
        }
    }
}
