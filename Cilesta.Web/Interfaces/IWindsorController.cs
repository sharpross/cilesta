namespace Cilesta.Web.Interfaces
{
    using Castle.Windsor;

    public interface IWindsorController
    {
        IWindsorContainer Container { get; set; }
    }
}
