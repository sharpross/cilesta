namespace Cilesta.Domain.Models
{
    public class FilterItem
    {
        public string Field { get; set; }

        public LogicalType Operation { get; set; }

        public object Value { get; set; }
    }
}
