namespace Cilesta.Web.Katarina.Implimentation
{
    using System.Web.Mvc;
    using Castle.Windsor;
    using Cilesta.Security.Katarina.Filtes;
    using Cilesta.Web.Katarina.Filtres;
    using Interfaces;

    public class FilterContainer : IFilterContainer
    {
        public IWindsorContainer Container { get; set; }

        public void Init(GlobalFilterCollection filterCollection)
        {
            filterCollection.Add(new AuthenticationFilterAttribute(this.Container));
            filterCollection.Add(new AuthorizeFilterAttribute(this.Container));

            filterCollection.Add(new CommonExceptionFilter(this.Container));
            filterCollection.Add(new NotFoundExceptionFilter(this.Container));
            filterCollection.Add(new UnauthorizedAccessExceptionFilter(this.Container));
        }
    }
}
