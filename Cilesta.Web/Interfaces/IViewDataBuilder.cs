namespace Cilesta.Web.Interfaces
{
    using System.Web.Mvc;
    using Castle.Windsor;

    public interface IViewDataBuilder
    {
        IWindsorContainer Container { get; set; }

        void Build(Controller contextController);
    }
}