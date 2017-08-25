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
        
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            if (filterContext.Exception is UnauthorizedAccessException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

                if (this.IsAjaxRequest(filterContext.HttpContext.Request))
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.Result = JsonNetResult.Fail(filterContext.Exception);
                }
                else
                {
                    filterContext.Result = new RedirectResult(VirtualPathUtility.ToAbsolute("~/Login/Index"), true);
                }
            }
        }
    }
}
