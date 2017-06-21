namespace Cilesta.Web.Katarina.Filtres
{
    using System.Web;
    using System.Web.Mvc;
    using Castle.Windsor;
    using Cilesta.Logging.Interfaces;
    using Cilesta.Web.Katarina.Implimentation;

    public class CilestaHandleErrorAttribute : FilterAttribute, IExceptionFilter
    {
        public IWindsorContainer Container { get; set; }

        public ILogger Logger { get; set; }

        public CilestaHandleErrorAttribute(IWindsorContainer container)
        {
            this.Container = container;
            this.Logger = this.Container.Resolve<ILogger>();
        }

        public void OnException(ExceptionContext filterContext)
        {
            this.Logger.Error(filterContext.Exception);

            if (this.IsAjaxRequest(filterContext.HttpContext.Request))
            {
                filterContext.Result = JsonNetResult.Fail(filterContext.Exception);
            }
        }

        private bool IsAjaxRequest(HttpRequestBase requestr)
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
