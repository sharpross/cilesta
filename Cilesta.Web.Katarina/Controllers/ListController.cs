namespace Cilesta.Web.Katarina.Controllers
{
    using System;
    using Cilesta.Data.Models;
    using Cilesta.Web.Katarina.Implimentation;
    using Cilesta.Web.Katarina.Models;
    using Filter = Domain.Katarina.Implimentation.Filter;

    public class ListController<T> : DomainController<T> where T : class, IEntity
    {
        public JsonNetResult List(ListParams? listParams)
        {
            var filter = new Filter();
            var page = 1;
            var count = 50;

            if (listParams.HasValue)
            {
                page = listParams.Value.Page ?? 0;
                count = listParams.Value.Count ?? 0;
            }

            try
            {
                var data = this.Service.GetAll(filter);

                return JsonNetResult.List(data, page, count);
            }
            catch (Exception ex)
            {
                return JsonNetResult.Error(ex);
            }
        }
    }
}
