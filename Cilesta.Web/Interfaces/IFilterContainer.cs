namespace Cilesta.Web.Interfaces
{
    using System.Web.Mvc;

    public interface IFilterContainer
    {
        void Init(GlobalFilterCollection filterCollection);
    }
}
