using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public abstract T Create(T entity, long? createdById = default(long?));
        public abstract T Update(T entity, long Id, long? createdById = default(long?));
        public abstract T Delete(long Id, long? createdById = default(long?));
        public abstract IEnumerable<T> GetAll();
        public abstract T? GetById( long Id );

    }
}
