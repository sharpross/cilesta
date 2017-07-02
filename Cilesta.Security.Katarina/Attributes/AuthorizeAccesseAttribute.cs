﻿namespace Cilesta.Security.Katarina.Attributes
{
    using System;
    using System.Linq;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;
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
