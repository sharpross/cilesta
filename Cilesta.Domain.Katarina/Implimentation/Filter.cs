namespace Cilesta.Domain.Katarina.Implimentation
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using NHibernate;
    using NHibernate.Criterion;
    using IFilter = Interfaces.IFilter;

    public class Filter : IFilter
    {
        private int skip;

        private int take;

        public Filter()
        {
            Items = new List<FilterItem>();
        }

        public IList<FilterItem> Items { get; set; }

        public void Add(string field, LogicalType operation, object value)
        {
            Items.Add(new FilterItem
            {
                Field = field,
                Operation = operation,
                Value = value
            });
        }

        public void Clear()
        {
            Items.Clear();
            skip = 0;
            take = 0;
        }

        public void Skip(int count)
        {
            skip = count;
        }

        public void Take(int count)
        {
            take = count;
        }

        public ICriteria Parse(ICriteria criteria)
        {
            foreach (var rec in Items)
            {
                switch (rec.Operation)
                {
                    case LogicalType.Eq:
                        criteria.Add(Restrictions.Eq(rec.Field, rec.Value));
                        break;
                    case LogicalType.Ge:
                        criteria.Add(Restrictions.Ge(rec.Field, rec.Value));
                        break;
                    case LogicalType.Gt:
                        criteria.Add(Restrictions.Gt(rec.Field, rec.Value));
                        break;
                    case LogicalType.In:
                        criteria.Add(Restrictions.In(rec.Field, new object[1] {rec.Value}));
                        break;
                    case LogicalType.Le:
                        criteria.Add(Restrictions.Le(rec.Field, rec.Value));
                        break;
                    case LogicalType.Like:
                        criteria.Add(Restrictions.Like(rec.Field, rec.Value));
                        break;
                    case LogicalType.Lt:
                        criteria.Add(Restrictions.Lt(rec.Field, rec.Value));
                        break;
                    case LogicalType.NotEq:
                        criteria.Add(Restrictions.Not(Restrictions.Eq(rec.Field, rec.Value)));
                        break;
                    case LogicalType.NotLike:
                        criteria.Add(Restrictions.Not(Restrictions.Like(rec.Field, rec.Value)));
                        break;
                    case LogicalType.NotNull:
                        criteria.Add(Restrictions.Not(Restrictions.IsNull(rec.Field)));
                        break;
                    case LogicalType.Null:
                        criteria.Add(Restrictions.IsNull(rec.Field));
                        break;
                }
            }

            if (take > 0)
            {
                criteria.SetMaxResults(take);
            }

            if (skip > 0)
            {
                criteria.SetFirstResult(skip);
            }

            return criteria;
        }
    }
}