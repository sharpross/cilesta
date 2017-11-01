namespace Cilesta.Web.Katarina.Filtres
{
    using System.Web;
    using System.Web.Mvc;
    using Castle.Windsor;
    using Logging.Interfaces;

    public abstract class BaseExceptionFilter
    {
        public BaseExceptionFilter(IWindsorContainer container)
        {
            Container = container;
            Logger = Container.Resolve<ILogger>();
        }

        protected IWindsorContainer Container { get; set; }

        protected ILogger Logger { get; set; }

        public abstract void ProcessRequest(ExceptionContext filterContext);

        public abstract void ProcessAjaxRequest(ExceptionContext filterContext);

        public abstract bool IsThisException(ExceptionContext filterContext);

        public virtual void OnException(ExceptionContext filterContext)
        {
            WriteToLog(filterContext);

            if (filterContext.ExceptionHandled)
            {
                return;
            }

            if (IsThisException(filterContext))
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

                if (IsAjaxRequest(filterContext.HttpContext.Request))
                {
                    ProcessAjaxRequest(filterContext);
                }
                else
                {
                    ProcessRequest(filterContext);
                }
            }
        }

        protected void WriteToLog(ExceptionContext filterContext)
        {
            Logger.Error(filterContext.Exception);
        }

        public bool IsAjaxRequest(HttpRequestBase requestr)
        {
            var result = false;

            var header = requestr.Headers["X-Requested-With"];

            if (header != null)
            {
                result = header == "XMLHttpRequest";
            }

            return result;
        }
    }
}