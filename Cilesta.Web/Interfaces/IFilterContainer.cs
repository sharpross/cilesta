namespace Cilesta.Web.Interfaces
{
    using System.Web.Mvc;
    using Castle.Windsor;

    public interface IFilterContainer
    {
        IWindsorContainer Container { get; set; }

        void Init(GlobalFilterCollection filterCollection);
    }
}
