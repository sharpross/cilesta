namespace Cilesta.Web.Katarina.Filtres
{
    using System.Web.Mvc;
    using Castle.Windsor;
    using Cilesta.Web.Katarina.Implimentation;

    public class NotFoundExceptionFilter : BaseExceptionFilter, IExceptionFilter
    {
        public NotFoundExceptionFilter(IWindsorContainer container)
            : base(container)
        {
        }

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            if (filterContext.Exception is NotFoundException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

                if (this.IsAjaxRequest(filterContext.HttpContext.Request))
                {
                    filterContext.HttpContext.Response.StatusCode = 404;
                    filterContext.Result = JsonNetResult.Fail(filterContext.Exception);
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Error/NotFound", false);
                }
            }
        }
    }
}
