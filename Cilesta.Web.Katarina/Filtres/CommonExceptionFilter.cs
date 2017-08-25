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

            if (!(filterContext.Exception is NotFoundException) && 
                !(filterContext.Exception is UnauthorizedAccessException))
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

                if (this.IsAjaxRequest(filterContext.HttpContext.Request))
                {
                    filterContext.HttpContext.Response.StatusCode = 500;
                    filterContext.Result = JsonNetResult.Fail(filterContext.Exception);
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Error/Index", false);
                }
            }
        }
    }
}
