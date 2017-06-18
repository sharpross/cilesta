namespace Cilesta.Web.Katarina.Implimentation
{
    using System.Web.Mvc;
    using Cilesta.Web.Katarina.Filtres;
    using Interfaces;

    public class FilterContainer : IFilterContainer
    {
        public void Init(GlobalFilterCollection filterCollection)
        {
            filterCollection.Add(new CilestaHandleErrorAttribute());
        }
    }
}
