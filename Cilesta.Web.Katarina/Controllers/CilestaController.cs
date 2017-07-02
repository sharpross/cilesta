namespace Cilesta.Web.Katarina.Controllers
{
    using System.Security.Principal;
    using System.Web.Mvc;
    using System.Web.Mvc.Filters;
    using Castle.Core.Logging;
    using Castle.Windsor;
    using Cilesta.Security.Katarina.Implimentation;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Web.Interfaces;

    public class CilestaController : Controller, ICilestaController
    {
        public IWindsorContainer Container { get; set; }

        public ILogger Log { get; set; }
        
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            var cookies = filterContext.HttpContext.Request.Cookies;
            
            IPrincipal principal = null;

            if (cookies == null || cookies[Security.Constants.CookieName] == null)
            {
                base.OnAuthentication(filterContext);
            }

            var cookieContext = cookies[Security.Constants.CookieName];
            
            if (cookieContext != null)
            {
                var authService = this.Container.Resolve<IAuthService>();

                var user = authService.GetUserFromCookie(cookieContext);

                IIdentity identity = new IndentityUser(user.Login);
                principal = new IdentityPrincipal(identity);
            }

            if (principal == null)
            {
                IIdentity user = new AnonymousUser();
                principal = new IdentityPrincipal(user);
            }

            filterContext.HttpContext.User = principal;

            base.OnAuthentication(filterContext);
        }
    }
}
