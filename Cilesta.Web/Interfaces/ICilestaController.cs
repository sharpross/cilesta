namespace Cilesta.Web.Interfaces
{
    using Castle.Core.Logging;
    using Castle.Windsor;

    public interface ICilestaController
    {
        IWindsorContainer Container { get; set; }

        ILogger Log { get; set; }
    }
}
