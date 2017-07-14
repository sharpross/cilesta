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
            var count = Domain.Constants.DefaultPageSize;

            if (listParams.HasValue)
            {
                page = listParams.Value.Page ?? 0;
                count = listParams.Value.Count ?? 0;
            }

            filter.Skip((page - 1)* count);
            filter.Take(count);

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
