using Core.Interfaces.Errors;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        public abstract IResult<T> Create(T entity, long? createdById = default(long?));
        public abstract IResult<bool> Update(T entity, long? updatedById = default(long?));
        public abstract IResult<bool> Delete(long Id, long? deletedById = default(long?));
        public IResult<IQueryable<T>> FindAll(
                    Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                    string includeProperties = null, int? skip = null, int? take = null,
                    bool? ignoreQueryFilters = false, bool asNoTracking = false);
        public abstract IResult<T> GetById( long Id );

    }
}
