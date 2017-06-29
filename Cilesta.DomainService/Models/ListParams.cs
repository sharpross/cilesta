namespace Cilesta.Domain.Models
{
    public class ListParams
    {
        public int Page { get; set; }

        public int Count { get; set; }

        public ListParams()
        {
            Page = 1;
            Count = 50;
        }
    }
}
