namespace Cilesta.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Cilesta.Data.Models;
    using NHibernate;

    public interface IBridge<T> where T : class, IEntity
    {
        ISession Session { get; }

        T Get(int id);

        IList<T> GetAll();

        void Save(T entity);

        void Save(IList<T> entities);

        void Delete(T entity);

        void Delete(IList<T> entities);
    }
}
