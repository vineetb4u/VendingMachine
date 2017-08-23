using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VendingMachine.Data.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Reset();
    }
}
