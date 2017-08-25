namespace Cilesta.Web.Katarina.Filtres
{
    using System.Web;
    using System.Web.Mvc;
    using Castle.Core.Logging;
    using Castle.Windsor;

    public class BaseExceptionFilter
    {
        protected IWindsorContainer Container { get; set; }

        protected Logging.Interfaces.ILogger Logger { get; set; }

        public BaseExceptionFilter(IWindsorContainer container)
        {
            this.Container = container;
            this.Logger = this.Container.Resolve<Logging.Interfaces.ILogger>();
        }

        public virtual void OnException(ExceptionContext filterContext)
        {
            this.WriteToLog(filterContext);

            if (filterContext.ExceptionHandled)
            {
                return;
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
