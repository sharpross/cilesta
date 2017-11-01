namespace Cilesta.Web.Katarina.Filtres
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using Castle.Windsor;
    using Cilesta.Web.Katarina.Implimentation;

    public class UnauthorizedAccessExceptionFilter : BaseExceptionFilter, IExceptionFilter
    {
        public UnauthorizedAccessExceptionFilter(IWindsorContainer container)
            : base(container)
        {
        }

        public override bool IsThisException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is UnauthorizedAccessException)
            {
                return true;
            }

            return false;
        }

        public override void ProcessRequest(ExceptionContext filterContext)
        {
            filterContext.Result = new RedirectResult(VirtualPathUtility.ToAbsolute("~/Login/Index"), false);
        }

        public override void ProcessAjaxRequest(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 401;
            filterContext.Result = JsonNetResult.Fail(filterContext.Exception);
        }
    }
}
