namespace Cilesta.Web.Interfaces
{
    using System.Web.ModelBinding;
    using Castle.Windsor;

    public interface ICilestaValueProvider : IValueProvider
    {
        IWindsorContainer Container { get; set; }
    }
}
