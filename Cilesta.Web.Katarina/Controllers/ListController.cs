namespace Cilesta.Web.Katarina.Controllers
{
    using Cilesta.Data.Models;
    using Cilesta.Domain.Interfaces;
    using Cilesta.Domain.Models;
    using Cilesta.Web.Katarina.Implimentation;

    public class ListController<T> : CilestaController where T : class, IEntity
    {
        private IDomainService<T> service { get; set; }
        public IDomainService<T> Service
        {
            get 
            {
                if (service == null)
                {
                    service = Container.Resolve<IDomainService<T>>();
                }

                return service;
            }
        }

        public JsonNetResult List(int? page, int? count)
        {
            var listParam = new ListParams()
            {
                Page = page.HasValue ? page.Value : 1,
                Count = count.HasValue ? count.Value : 50
            };

            var data = this.Service.List(listParam);

            return JsonNetResult.List(data, page, count);
        }
    }
}
