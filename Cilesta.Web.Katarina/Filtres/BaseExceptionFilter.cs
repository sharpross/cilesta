namespace Cilesta.Web.Katarina.Filtres
{
    using System.Web;
    using System.Web.Mvc;
    using Castle.Core.Logging;
    using Castle.Windsor;

    public abstract class BaseExceptionFilter
    {
        protected IWindsorContainer Container { get; set; }

        protected Logging.Interfaces.ILogger Logger { get; set; }

        public BaseExceptionFilter(IWindsorContainer container)
        {
            this.Container = container;
            this.Logger = this.Container.Resolve<Logging.Interfaces.ILogger>();
        }

        public abstract void ProcessRequest(ExceptionContext filterContext);

        public abstract void ProcessAjaxRequest(ExceptionContext filterContext);

        public abstract bool IsThisException(ExceptionContext filterContext);

        public virtual void OnException(ExceptionContext filterContext)
        {
            this.WriteToLog(filterContext);

            if (filterContext.ExceptionHandled)
            {
                return;
            }

            if (this.IsThisException(filterContext))
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

                if (this.IsAjaxRequest(filterContext.HttpContext.Request))
                {
                    this.ProcessAjaxRequest(filterContext);
                }
                else
                {
                    this.ProcessRequest(filterContext);
                }
            }
        }

        protected void WriteToLog(ExceptionContext filterContext)
        {
            this.Logger.Error(filterContext.Exception);
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
