namespace Cilesta.Web.Interfaces
{
    using Castle.Core.Logging;
    using Cilesta.Core;

    public interface ICilestaController : IWindsorController
    {
        ILogger Log { get; set; }
    }
}
