using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Relationships.DAL.Context;
using Relationships.DAL.Interfaces;
using Relationships.DAL.Models;

namespace Relationships.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity :  class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;
 
        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
 
        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
         
        public IEnumerable<TEntity> GetByPredicate(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
        public TEntity FindById(long id)
        {
            return _dbSet.Find(id);
        }
 
        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public IList<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {
                _dbSet.Include(includeProperty);
            }

            return _dbSet.ToList();
        }
    }
}