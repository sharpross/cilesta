namespace Cilesta.Web.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Cilesta.Utils.Json;
    using Cilesta.Web.Katarina.Models;

    public class JsonNetResult : ActionResult
    {
        public object Data { get; set; }

        public int StatusCode { get; private set; }

        public string ContentType { get; private set; }

        public string Exception { get; private set; }

        public bool IsSuccess { get; private set; }
        
        public JsonNetResult() : base()
        {
            this.StatusCode = 200;
            this.ContentType = "application/json";
            this.IsSuccess = true;
            this.Exception = null;
        }

        public static JsonNetResult Success()
        {
            return new JsonNetResult();
        }

        public static JsonNetResult Success(string message)
        {
            return new JsonNetResult()
            {
                Data = message
            };
        }

        public static JsonNetResult Success(object data)
        {
            return new JsonNetResult()
            {
                Data = data
            };
        }

        public static JsonNetResult List(IList<object> list)
        {
            return new JsonNetResult()
            {
                Data = list
            };
        }

        public static JsonNetResult Fail(object data)
        {
            return new JsonNetResult()
            {
                StatusCode = 500,
                Data = data,
                IsSuccess = false
            };
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;

            response.ContentType = this.ContentType;
            response.StatusCode = this.StatusCode;

            var result = new JsonResultModel()
            {
                Status = this.StatusCode,
                Result = this.Data,
                Exception = this.Exception
            };

            var resultStr = JsonHelper.Serialize(result);

            using (var writer = response.Output)
            {
                writer.WriteLine(resultStr);
            }
        }
    }
}
