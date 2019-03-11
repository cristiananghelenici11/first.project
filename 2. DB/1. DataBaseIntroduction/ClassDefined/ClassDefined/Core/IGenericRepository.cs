using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDefined.Core
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T item);
        T FindById(long id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
    }
}
