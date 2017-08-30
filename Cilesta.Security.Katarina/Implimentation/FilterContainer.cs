namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Web.Mvc;
    using Castle.Windsor;
    using Cilesta.Security.Katarina.Attributes;
    using Cilesta.Web.Interfaces;

    public class FilterContainer : IFilterContainer
    {
        public IWindsorContainer Container { get; set; }

        public void Init(GlobalFilterCollection filterCollection)
        {
            filterCollection.Add(new AuthorizeControlAttribute());
        }
    }
}
