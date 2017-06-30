namespace Cilesta.Web.Katarina.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Data.Models;
    using Cilesta.Security.Katarina.Attributes;
    using Cilesta.Web.Katarina.Implimentation;

    [AuthorizeAccesse]
    public class DataController<T> : ListController<T> where T : class, IEntity
    {
        [HttpGet]
        public JsonNetResult Get(int id)
        {
            var obj = this.Service.Get(id);

            if (obj != null)
            {
                return JsonNetResult.Success(obj);
            }

            return JsonNetResult.Fail(null);
        }

        [HttpGet]
        public JsonNetResult GetAll()
        {
            var list = this.Service.GetAll();

            if (list != null)
            {
                return JsonNetResult.Success(list);
            }

            return JsonNetResult.Fail(null);
        }
    }
}
