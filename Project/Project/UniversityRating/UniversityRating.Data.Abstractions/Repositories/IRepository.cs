using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityRating.Data.Abstractions.Interfaces;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        TEntity GetById(long id);

        TEntity GetById(long id, ISpecification<TEntity> specification);

        IEnumerable<TEntity> Find(ISpecification<TEntity> specification = null);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        int SaveChanges();
    }
}