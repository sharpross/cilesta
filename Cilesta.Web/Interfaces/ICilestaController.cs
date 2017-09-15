namespace Cilesta.Web.Interfaces
{
    using Castle.Core.Logging;

    public interface ICilestaController : IWindsorController
    {
        ILogger Log { get; set; }
    }
}
