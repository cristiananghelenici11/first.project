using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private List<T> _dbEntity;

        public GenericRepository(IEnumerable<T> dbEntity)
        {
            _dbEntity = dbEntity.ToList();
        }
        public void Create(T item)
        {
            _dbEntity.Add(item);
        }

        public T FindById(int id)
        {
            return _dbEntity.Find(x => x.ID == id);
        }

        public IEnumerable<T> Get()
        {
            return _dbEntity;
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _dbEntity.Where(predicate);
        }

        public void Remove(T item)
        {
            _dbEntity.Remove(item);
        }

        public void Update(T item)
        {
            int index = _dbEntity.FindIndex(e => e.ID == item.ID);

            if (index != -1)
                _dbEntity[index] = item;
        }
    }
}
