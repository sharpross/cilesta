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
        }

        public override bool IsThisException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is NotFoundException)
            {
                return true;
            }

            return false;
        }

        public override void ProcessRequest(ExceptionContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Error/NotFound", false);
        }

        public override void ProcessAjaxRequest(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 404;
            filterContext.Result = JsonNetResult.Fail(filterContext.Exception);
        }
    }
}
