namespace Cilesta.Security.Katarina.Filtes
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Castle.Windsor;
    using Cilesta.Security.Katarina.Attributes;

    public class AuthorizeFilterAttribute : FilterAttribute, IAuthorizationFilter
    {
        public IWindsorContainer Container { get; set; }

        public AuthorizeFilterAttribute(IWindsorContainer container)
        {
            this.Container = container;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.Skip(filterContext))
            {
                return;
            }

            var user = filterContext.HttpContext.User;

            if (user != null && user.Identity.IsAuthenticated)
            {
                return;
            }

            throw new UnauthorizedAccessException(Constants.UnauthorizedAccess);
        }

        private bool Skip(AuthorizationContext filterContext)
        {
            var result = false;

            var skipMethod = filterContext.ActionDescriptor
                .GetCustomAttributes(false)
                .Any(x => x is SkipAuthorizationAttribute);

            if (skipMethod)
            {
                return true;
            }

            var skipController = filterContext.Controller.GetType()
                .GetCustomAttributes(false)
                .Any(x => x is SkipAuthorizationAttribute);

            if (skipController)
            {
                result = true;
            }

            return result;
        }
    }
}
