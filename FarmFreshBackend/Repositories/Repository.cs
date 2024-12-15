using Core.Enumeration;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Errors;
using Core.Models;
using Core.Models.Errors;
using FarmFreshBackend.DataSet;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace FarmFreshBackend.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DataContext            _dbContext;
        private readonly DbSet<T>               _dbSet;
        private readonly ILogger<Repository<T>> _logger;
       
        public Repository(DataContext dbContext, ILogger<Repository<T>> logger)
        {
            _dbContext = dbContext;
            _dbSet     = _dbContext.Set<T>();
            _logger    = logger;
          }

        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet     = _dbContext.Set<T>();
        }

        public virtual IResult<T> Create(T entity, long? createdById = null)
        {
            var result = new Result<T>();
            try
            {
                if (entity is ICreatable)
                {
                    if (createdById.HasValue)
                    {
                        ((ICreatable)entity).CreatedById = createdById.Value;
                    }

                   ((ICreatable)entity).CreatedOn = DateTimeOffset.Now;
                }

                 var outputData = _dbSet.Add(entity);
                _dbContext.SaveChanges();
                result.ResultObject = entity;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while creating User: {ex.Message}");

                result.AddError(ErrorType.Error,ex.GetType().ToString(),ex.Message);
              
            }
         return result;
        }

        public virtual IResult<bool> Delete(long Id, long? deletedById = null)
        {
            IResult<T> result;
                result = GetById(Id);

            try
            {
                if (result != null || result.ResultObject != null)
                {
                    if (result.ResultObject is IDeletable)
                    {
                        ((IDeletable)result.ResultObject).DeletedOn = DateTimeOffset.Now;
                        ((IDeletable)result.ResultObject).DeletedById = deletedById;
                    }
                    if (result.HasErrors)
                    {
                        return new Result<bool>
                        {
                            Errors       = result.Errors,
                            ResultObject = false
                        };
                    }
                    _dbSet.Update(result.ResultObject);
                    _dbContext.SaveChanges();

                    return new Result<bool>
                    {
                        Errors       = result.Errors,
                        ResultObject = true
                    };
                }
                return new Result<bool>
                {
                   ResultObject = false
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while deleting User: {ex.Message}");

                return new Result<bool>
                {
                    Errors = new List<IError>
                        {
                            new Error
                            {
                                ErrorType = ErrorType.Error,
                                Key       = ex.GetType().ToString(),
                                Message   = ex.Message
                            }
                        },
                    ResultObject = false
                };
            }   
        }

        public IResult<IQueryable<T>> FindAll(
            Expression<Func<T, bool>> filter                  = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties                          = null,
            int? skip                                         = null,
            int? take                                         = null,
            bool? ignoreQueryFilters                          = false,
            bool asNoTracking                                 = false)
        {
            var result = new Result<IQueryable<T>>
            {
                ResultObject = Enumerable.Empty<T>().AsQueryable(), // Default initialization
                Errors = new List<IError>()
            };

            try
            {
                IQueryable<T> query = _dbSet;

                if (ignoreQueryFilters == true)
                {
                    query = query.IgnoreQueryFilters();
                }

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }

                if (asNoTracking)
                {
                    query = query.AsNoTracking();
                }

                if (orderBy != null)
                {
                    query = orderBy(query);
                }

                if (skip.HasValue)
                {
                    query = query.Skip(skip.Value);
                }

                if (take.HasValue)
                {
                    query = query.Take(take.Value);
                }

                result.ResultObject = query;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting User: {ex.Message}");

                result.Errors.Add(new Error
                {
                    ErrorType = ErrorType.Error,
                    Key = ex.Message,
                    Message = ex.GetType().ToString()
                });
            }

            return result;
        }

        public IResult<T> GetById(long id)
        {
            IResult<T> findResult = new Result<T>();
            try
            {
                _logger.LogInformation("Testing information");
                var result = _dbSet.Find(id);
                if (result != null && ((IDeletable)result).DeletedById == null)
                {
                    findResult.ResultObject = result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting User: {ex.Message}");
                findResult.AddError(ErrorType.Error, ex.GetType().ToString(), ex.Message);
            }
            return findResult;
        }

        public IResult<bool> Update(T entity, long? updatedById = null)
        {
            var result = new Result<bool> { ResultObject = false};
            try
            {
                if (entity is IUpdatable)
                {
                    if (updatedById.HasValue)
                    {
                        ((IUpdatable)entity).UpdatedById = updatedById.Value;
                        ((IUpdatable)entity).UpdatedOn = DateTimeOffset.Now;
                    }
                    var updateResult = _dbSet.Update(entity);
                    _dbContext.SaveChanges();
                    result.ResultObject = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while updating User: {ex.Message}");

                result.AddError(ErrorType.Error, ex.GetType().ToString(), ex.Message);
            }
            return result;
        }
    }
}
