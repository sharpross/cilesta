namespace Cilesta.Web.Katarina.Filtres
{
    using System;
    using System.Web.Mvc;
    using Castle.Windsor;
    using Cilesta.Web.Katarina.Implimentation;

    public class CommonExceptionFilter : BaseExceptionFilter, IExceptionFilter
    {
        public CommonExceptionFilter(IWindsorContainer container)
            : base(container)
        {
        }

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        public override bool IsThisException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is NotFoundException ||
                filterContext.Exception is UnauthorizedAccessException)
            {
                return false;
            }

            return true;
        }

        public override void ProcessRequest(ExceptionContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Error/Index", false);
        }

        public override void ProcessAjaxRequest(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.Result = JsonNetResult.Fail(filterContext.Exception);
        }
    }
}
