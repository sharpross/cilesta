namespace Cilesta.Security.Katarina.Attributes
{
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;
    using Castle.Windsor;
    using Cilesta.Core;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Security.Models;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AuthorizeAccesseAttribute : FilterAttribute, IAuthorizationFilter
    {
        public string AccessKey { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var cookies = filterContext.HttpContext.Request.Cookies;

            IUserIndentity identity = null;

            var container = ((IWindsorController)filterContext.Controller).Container;

            var authService = container.Resolve<IAuthService>();
            var currentUser = authService.GetCurrentUser(filterContext.HttpContext.Request);

            if (currentUser != null)
            {
                identity = new IndentityUser(currentUser.Login);
            }
            else
            {
                identity = new AnonymousUser();
            }

            var userInfo = new GenericPrincipal(identity, null);
            HttpContext.Current.User = userInfo;
        }
    }
}
