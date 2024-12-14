using Core.Interfaces;
using Core.Models;
using FarmFreshBackend.DataSet;
using Microsoft.EntityFrameworkCore;

namespace FarmFreshBackend.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dbContext;
        private readonly DbSet<T>    _dbSet;

        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet     = _dbContext.Set<T>();
          }

       public T? Create(T entity, long? createdById = null)
        {
            if (entity is ICreatable)
            {
                if (createdById.HasValue)
                {
                    ((ICreatable)entity).CreatedById = createdById.Value;
                }
           
                    ((ICreatable)entity).CreatedOn   = DateTimeOffset.Now;
            }
            
            var result = _dbSet.Add(entity);
            _dbContext.SaveChanges();
            if (result != null)
            {
                return result.Entity;
            }
            return null;
        }

        public T Delete(long Id, long? createdById = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T? GetById(long id)
        {
            var result = _dbSet.Find(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }


        public T Update(T entity, long Id, long? createdById = null)
        {
            throw new NotImplementedException();
        }
    }
}
