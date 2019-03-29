using System;
using System.Collections.Generic;

namespace Relationships.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity FindById(long id);
        IList<TEntity> GetAll();
        IEnumerable<TEntity> GetByPredicate(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}