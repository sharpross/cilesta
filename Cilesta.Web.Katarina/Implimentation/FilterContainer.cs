namespace Cilesta.Web.Katarina.Implimentation
{
    using System;
    using System.Web.Mvc;
    using Castle.Windsor;
    using Cilesta.Web.Katarina.Filtres;
    using Interfaces;

    public class FilterContainer : IFilterContainer
    {
        public IWindsorContainer Container { get; set; }

        public void Init(GlobalFilterCollection filterCollection)
        {
            filterCollection.Add(new CilestaHandleErrorAttribute(this.Container));
        }
    }
}
