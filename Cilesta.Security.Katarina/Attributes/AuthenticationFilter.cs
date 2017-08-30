namespace Cilesta.Security.Katarina.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using System.Web.Mvc.Filters;
    using Castle.Windsor;
    using Cilesta.Security.Interfaces;
    using Cilesta.Security.Katarina.Implimentation;
    using Cilesta.Security.Katarina.Models;

    public class AuthenticationFilter : FilterAttribute, IAuthenticationFilter
    {
        public IWindsorContainer Container { get; set; }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var cookies = filterContext.HttpContext.Request.Cookies;

            IPrincipal principal = null;

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

            filterContext.Principal = principal;
            filterContext.HttpContext.User = principal;
            Thread.CurrentPrincipal = principal;
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.HttpContext.User == null)
            {
                throw new UnauthorizedAccessException();
            }

            //throw new NotImplementedException();
        }
    }
}
