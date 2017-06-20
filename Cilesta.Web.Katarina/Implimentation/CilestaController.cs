namespace Cilesta.Web.Katarina.Implimentation
{
    using System;
    using System.Web.Mvc;
    using Castle.Core.Logging;
    using Castle.Windsor;
    using Cilesta.Utils.Json;
    using Cilesta.Web.Interfaces;
    using Cilesta.Web.Katarina.Models;

    public class CilestaController : Controller, ICilestaController
    {
        public IWindsorContainer Container { get; set; }

        public ILogger Log { get; set; }

        public CilestaController()
        {

        }

        public string JsonSuccess(object data)
        {
            this.Response.Status = "200";

            var model = this.JsonResult(data, string.Empty, null);

            var result = JsonHelper.Serialize(model);

            return result;
        }

        public JsonResultModel JsonResult(object obj, string message, Exception ex)
        {
            var result = new JsonResultModel();
            
            return result;
        }
    }
}
