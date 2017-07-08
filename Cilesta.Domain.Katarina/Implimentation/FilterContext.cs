namespace Cilesta.Domain.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using Cilesta.Domain.Interfaces;
    using NHibernate;
    using NHibernate.Criterion;

    public class FilterContext : IFilterContext
    {
        private List<ExpressionMap> map { get; set; }

        private int limit = 0;

        private int max = 0;

        public FilterContext()
        {
            this.map = new List<ExpressionMap>();
        }
        
        public void Add(string field, LogicalType logical, object value)
        {
            this.map.Add(new ExpressionMap()
            {
                Field = field,
                Logical = logical,
                Value = value
            });
        }

        public void SetLimit(int limit)
        {
            this.limit = limit;
        }

        public void SetMax(int max)
        {
            this.max = max;
        }

        public ICriteria Parse(ICriteria criteria)
        {
            foreach (var rec in map)
            {
                switch (rec.Logical)
                {
                    case LogicalType.Like:
                        criteria.Add(Expression.Like(rec.Field, rec.Value));
                        break;
                    case LogicalType.Less:
                        criteria.Add(Expression.Lt(rec.Field, rec.Value));
                        break;
                    case LogicalType.Greate:
                        criteria.Add(Expression.Gt(rec.Field, rec.Value));
                        break;
                    case LogicalType.NotEquals:
                        criteria.Add(Expression.Not(Expression.Eq(rec.Field, rec.Value)));
                        break;
                    case LogicalType.Equals:
                    default:
                        criteria.Add(Expression.Eq(rec.Field, rec.Value));
                        break;
                }
            }
            
            if (max > 0)
            {
                criteria.SetMaxResults(this.limit);
            }

            if (limit > 0)
            {
                criteria.SetFirstResult(this.limit);
            }

            return criteria;
        }

        private class ExpressionMap
        {
            public string Field { get; set; }

            public LogicalType Logical { get; set; }

            public object Value { get; set; }
        }
    }
}
