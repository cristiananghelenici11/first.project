using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public interface IGenericRepository<Tentity> where Tentity : class
    {
        void Create(Tentity item);
        Tentity FindById(int id);
        IEnumerable<Tentity> Get();
        IEnumerable<Tentity> Get(Func<Tentity, bool> predicate);
        void Remove(Tentity item);
        void Update(Tentity item);

    }
}
