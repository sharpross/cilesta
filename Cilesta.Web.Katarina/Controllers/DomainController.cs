namespace Cilesta.Web.Katarina.Controllers
{
    using System;
    using System.Web.Mvc;
    using Cilesta.Data.Models;
    using Cilesta.Domain.Interfaces;
    using Cilesta.Web.Katarina.Implimentation;
    using Filter = Domain.Katarina.Implimentation.Filter;

    public class DomainController<T> : BaseController where T : class, IEntity
    {
        private IDomainService<T> service { get; set; }
        public IDomainService<T> Service
        {
            get
            {
                if (service == null)
                {
                    service = this.Container.Resolve<IDomainService<T>>();
                }

                return service;
            }
        }

        [HttpGet]
        [OutputCache(Duration = 10)]
        public JsonNetResult Get(int id)
        {
            try
            {
                return JsonNetResult.Success(this.Service.Get(id));
            }
            catch (Exception ex)
            {
                return JsonNetResult.Error(ex);
            }
        }

        /*[HttpGet]
        [OutputCache(Duration = 10)]
        public JsonNetResult GetAll()
        {
            return this.GetAll(new Filter());
        }*/

        [HttpGet]
        [OutputCache(Duration = 10)]
        public JsonNetResult GetAll(Filter filter)
        {
            try
            {
                var data = this.Service.GetAll();

                return JsonNetResult.Success(data);
            }
            catch (Exception ex)
            {
                return JsonNetResult.Error(ex);
            }
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public JsonNetResult Delete(int id)
        {
            try
            {
                this.Service.Delete(id);

                return JsonNetResult.Success();
            }
            catch (Exception ex)
            {
                return JsonNetResult.Error(ex);
            }
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public JsonNetResult Delete(T entity)
        {
            try
            {
                this.Service.Delete(entity);

                return JsonNetResult.Success();
            }
            catch (Exception ex)
            {
                return JsonNetResult.Error(ex);
            }
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public JsonNetResult Save(T entity)
        {
            try
            {
                this.Service.Save(entity);

                return JsonNetResult.Success(entity);
            }
            catch (Exception ex)
            {
                return JsonNetResult.Error(ex);
            }
        }
    }
}
