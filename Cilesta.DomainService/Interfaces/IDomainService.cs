namespace Cilesta.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Cilesta.Data.Models;
    using Cilesta.Domain.Models;
    using Cilesta.Logging.Interfaces;

    public interface IDomainService<T> where T : class, IEntity
    {
        ILogger Log { get; }

        T Get(int id);

        IList<T> GetAll();
        
        void Save(T entity);

        void Save(IList<T> entities);

        void Delete(T entity);

        void Delete(IList<T> entities);

        IList<T> List(ListParams listParams);

        bool OnBefore(OperationType operation, object obj);

        void OnAfter(OperationType operation, object obj);
    }
}
