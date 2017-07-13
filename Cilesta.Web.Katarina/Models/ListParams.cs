namespace Cilesta.Web.Katarina.Models
{
    using System;
    using Cilesta.Domain.Katarina.Implimentation;

    public struct ListParams
    {
        public int? Count { get; set; }

        public int? Page { get; set; }

        public Filter Filter { get; set; }
    }
}
