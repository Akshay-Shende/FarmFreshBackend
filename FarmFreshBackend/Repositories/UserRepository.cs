using Core.Dtos.LoginDtos;
using Core.Enumeration;
using Core.Extensions;
using Core.Helper;
using Core.Interfaces;
using Core.Interfaces.Errors;
using Core.Interfaces.Repositories;
using Core.Models.Errors;
using Core.Models.Users;
using FarmFreshBackend.DataSet;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace FarmFreshBackend.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public IResult<User> Create(User entity, long? createdById = null)
        {
           var hashedPassword = PasswordHasherAndSalter.HashPassword(entity.Password);
            entity.Password= hashedPassword;
            return base.Create(entity, createdById);
        }

        public IResult<bool> Delete(long Id, long? deletedById = null)
        {
            return base.Delete(Id, deletedById);
        }

        public IResult<IQueryable<User>> FindAll(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null, bool? ignoreQueryFilters = false, bool asNoTracking = false)
        
 => base.FindAll(filter,orderBy,includeProperties,skip,take,ignoreQueryFilters,asNoTracking);
        

        public IResult<User> GetById(long Id) => base.GetById(Id);

        public IResult<User> loginUser(LoginDto dto)
        {
            var finalResult = new Result<User>();

            try
            {
                var result = GetById(dto.Id);
                if (result.HasErrors)
                {

                }
                var userData = result.ResultObject;
                var verifyPasswordResult = PasswordHasherAndSalter.VerifyPassword(dto.Password, userData.Password);

                finalResult.ResultObject = userData;
            }
            catch (Exception ex)
            {
                finalResult.AddError(ErrorType.Error, ex.GetType().ToString(), ex.Message);
            }
            return finalResult;
            }

        public IResult<bool> Update(User entity, long? updatedById = null) =>  base.Update(entity, updatedById);
        
    }
}
