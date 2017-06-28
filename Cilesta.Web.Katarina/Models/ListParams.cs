using System;

namespace Cilesta.Web.Katarina.Models
{
    public class ListParams : Nullable
    {
        public int Count { get; set; }

        public int Page { get; set; }
    }
}
