namespace Cilesta.Web.Katarina.Models
{
    public class JsonResultModel
    {
        public int Status { get; set; }

        public object Result { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

        public int? Page { get; set; }

        public int? Count { get; set; }
    }
}
