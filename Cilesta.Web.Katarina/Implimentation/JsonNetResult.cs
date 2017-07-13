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
    using Newtonsoft.Json;

    public class JsonNetResult : ActionResult
    {
        [JsonProperty("Data")]
        public object Data { get; set; }

        public int StatusCode { get; private set; }

        public string ContentType { get; private set; }

        [JsonProperty("Exception")]
        public string Exception { get; private set; }

        public bool IsSuccess { get; private set; }
        
        [JsonProperty("Count")]
        public int? Count { get; set; }

        [JsonProperty("Page")]
        public int? Page { get; set; }

        [JsonProperty("Page")]
        public bool? IsList { get; set; }

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

        public static JsonNetResult List(object list, int? page, int? count)
        {
            return new JsonNetResult()
            {
                Data = list,
                IsList = true,
                Count = count,
                Page = page,
            };
        }

        public static JsonNetResult Error(Exception ex)
        {
            return new JsonNetResult()
            {
                StatusCode = 500,
                Exception = ex.Message,
                IsSuccess = false
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
                Exception = this.Exception,
                Count = this.Count,
                Page = this.Page
            };

            var resultStr = JsonHelper.Serialize(result);

            using (var writer = response.Output)
            {
                writer.WriteLine(resultStr);
            }
        }
    }
}
