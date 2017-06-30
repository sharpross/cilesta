namespace Cilesta.Core
{
    using Castle.Windsor;

    public interface IWindsorController
    {
        IWindsorContainer Container { get; set; }
    }
}
