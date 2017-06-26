namespace Cilesta.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Cilesta.Data.Models;
    using Cilesta.Logging.Interfaces;

    public interface IDataService<T> where T: class, IEntity
    {
        ILogger Log { get; }

        T Get(ulong id);

        IList<T> GetAll();

        IList<T> GetAll(Expression<Func<T>> alias);

        void Save(T entity);

        void Save(IList<T> entities);

        void Delete(T entity);

        void Delete(IList<T> entities);

        bool OnBefore(OperationType operation, object obj);
    }
}
