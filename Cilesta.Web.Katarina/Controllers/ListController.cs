namespace Cilesta.Web.Katarina.Controllers
{
    using Cilesta.Data.Models;
    using Cilesta.Domain.Interfaces;
    using Cilesta.Web.Katarina.Implimentation;
    using Cilesta.Web.Katarina.Models;

    public class ListController<T> : CilestaController where T : class, IEntity
    {
        public IDomainService<T> Service { get; set; }

        public JsonNetResult List(ListParams listParams)
        {
            return JsonNetResult.Success();
        }
    }
}
