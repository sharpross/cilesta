namespace Cilesta.Domain.Interfaces
{
    using System.Collections.Generic;
    using Cilesta.Data.Interfaces;
    using Cilesta.Domain.Models;

    public interface IFilter : IFilterParser
    {
        IList<FilterItem> Items { get; set; } 

        void Add(string field, LogicalType logical, object value);

        void Skip(int count);

        void Take(int count);
    }
}
