using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDefined.DataModel;

namespace ClassDefined.Core
{
    public class GenericRepository<T> : IGenericRepository<T>
            where T : BaseEntity
    {
        private readonly List<T> _dbEntity;

        public GenericRepository(IEnumerable<T> dbEntity)
        {
            _dbEntity = dbEntity.ToList();
        }
        public void Create(T item)
        {
            _dbEntity.Add(item);
        }

        public T FindById(long id)
        {
            return _dbEntity.Find(e => e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbEntity;
        }

        public IEnumerable<T> GetBy(Func<T, bool> predicate)
        {
            return _dbEntity.Where(predicate);
        }

        public void Remove(T item)
        {
            _dbEntity.Remove(item);
        }

        public void Update(T item)
        {
            int index = _dbEntity.FindIndex(e => e.Id == item.Id);

            if (index != -1)
            {
                _dbEntity[index] = item;
            }
        }
    }
}
