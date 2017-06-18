namespace Cilesta.Web.Katarina.Implimentation
{
    using System.Web.Mvc;
    using Castle.Core.Logging;
    using Castle.Windsor;
    using Cilesta.Web.Interfaces;

    public class CilestaController : Controller, ICilestaController
    {
        public IWindsorContainer Container { get; set; }

        public ILogger Log { get; set; }

        public CilestaController()
        {

        }
    }
}
