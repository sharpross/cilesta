namespace Cilesta.Security.Katarina.Filtes
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Mvc.Filters;
    using Castle.Windsor;
    using Cilesta.Security.Interfaces;
    using Cilesta.Security.Katarina.Implimentation;
    using Cilesta.Security.Katarina.Models;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AuthenticationFilterAttribute : FilterAttribute, IAuthenticationFilter
    {
        public IWindsorContainer Container { get; set; }

        public AuthenticationFilterAttribute(IWindsorContainer container)
        {
            this.Container = container;
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var cookies = filterContext.HttpContext.Request.Cookies;

            IPrincipal principal = null;

            var cookieContext = cookies[Security.Constants.CookieName];

            if (cookieContext != null)
            {
                var authService = this.Container.Resolve<IAuthService>();

                var user = authService.GetUserFromCookie(cookieContext);

                if(user != null)
                {
                    IIdentity identity = new IndentityUser(user.Login);
                    principal = new IdentityPrincipal(identity);
                }
            }

            if (principal == null)
            {
                IIdentity user = new AnonymousUser();
                principal = new IdentityPrincipal(user);
            }

            filterContext.Principal = principal;
            filterContext.HttpContext.User = principal;
            Thread.CurrentPrincipal = principal;
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}
