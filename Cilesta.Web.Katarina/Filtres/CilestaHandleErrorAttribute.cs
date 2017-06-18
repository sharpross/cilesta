namespace Cilesta.Web.Katarina.Filtres
{
    using System;
    using System.Web.Mvc;
    using Cilesta.Logging.Interfaces;

    public class CilestaHandleErrorAttribute : FilterAttribute, IExceptionFilter
    {
        public ILogger Logger { get; set; }

        public void OnException(ExceptionContext filterContext)
        {
            this.Logger.Error(filterContext.Exception);
        }
    }
}
