namespace Cilesta.Web.Katarina.Implimentation
{
    using System.Web.Mvc;
    using Castle.Windsor;
    using Cilesta.Web.Katarina.Filtres;
    using Interfaces;

    public class FilterContainer : IFilterContainer
    {
        public IWindsorContainer Container { get; set; }

        public void Init(GlobalFilterCollection filterCollection)
        {
            filterCollection.Add(new CommonExceptionFilter(this.Container));
            filterCollection.Add(new NotFoundExceptionFilter(this.Container));
            filterCollection.Add(new UnauthorizedAccessExceptionFilter(this.Container));
        }
    }
}
