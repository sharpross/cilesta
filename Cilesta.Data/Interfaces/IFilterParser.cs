namespace Cilesta.Data.Interfaces
{
    using NHibernate;

    public interface IFilterParser
    {
        ICriteria Parse(ICriteria criteria);
    }
}
