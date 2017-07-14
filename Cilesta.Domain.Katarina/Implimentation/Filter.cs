namespace Cilesta.Domain.Katarina.Implimentation
{
    using System.Collections.Generic;
    using Cilesta.Domain.Models;
    using NHibernate;
    using NHibernate.Criterion;

    public class Filter : Interfaces.IFilter
    {
        public IList<FilterItem> Items { get; set; }

        private int skip = 0;

        private int take = 0;

        public Filter()
        {
            this.Items = new List<FilterItem>();
        }
        
        public void Add(string field, LogicalType operation, object value)
        {
            this.Items.Add(new FilterItem()
            {
                Field = field,
                Operation = operation,
                Value = value
            });
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
            foreach (var rec in this.Items)
            {
                switch (rec.Operation)
                {
                    case LogicalType.Eq:
                        criteria.Add(Expression.Eq(rec.Field, rec.Value));
                        break;
                    case LogicalType.Ge:
                        criteria.Add(Expression.Ge(rec.Field, rec.Value));
                        break;
                    case LogicalType.Gt:
                        criteria.Add(Expression.Gt(rec.Field, rec.Value));
                        break;
                    case LogicalType.In:
                        criteria.Add(Expression.In(rec.Field, new object[1] { rec.Value }));
                        break;
                    case LogicalType.Le:
                        criteria.Add(Expression.Le(rec.Field, rec.Value));
                        break;
                    case LogicalType.Like:
                        criteria.Add(Expression.Like(rec.Field, rec.Value));
                        break;
                    case LogicalType.Lt:
                        criteria.Add(Expression.Lt(rec.Field, rec.Value));
                        break;
                    case LogicalType.NotEq:
                        criteria.Add(Expression.Not(Expression.Eq(rec.Field, rec.Value)));
                        break;
                    case LogicalType.NotLike:
                        criteria.Add(Expression.Not(Expression.Like(rec.Field, rec.Value)));
                        break;
                    case LogicalType.NotNull:
                        criteria.Add(Expression.Not(Expression.IsNull(rec.Field)));
                        break;
                    case LogicalType.Null:
                        criteria.Add(Expression.IsNull(rec.Field));
                        break;
                }
            }
            
            if (take > 0)
            {
                criteria.SetMaxResults(this.take);
            }

            if (skip > 0)
            {
                criteria.SetFirstResult(this.skip);
            }

            return criteria;
        }
    }
}
