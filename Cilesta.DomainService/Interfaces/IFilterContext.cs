namespace Cilesta.Domain.Interfaces
{
    using Cilesta.Data.Interfaces;

    public interface IFilterContext : IFilterParser
    {
        void Add(string field, LogicalType logical, object value);

        void SetLimit(int limit);

        void SetMax(int max);
    }
}
