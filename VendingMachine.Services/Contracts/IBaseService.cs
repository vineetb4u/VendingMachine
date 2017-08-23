using System.Collections.Generic;

namespace VendingMachine.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Reset();
    }
}
