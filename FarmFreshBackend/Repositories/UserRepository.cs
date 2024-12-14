using Core.Interfaces.Repositories;
using Core.Models.Users;
using FarmFreshBackend.DataSet;

namespace FarmFreshBackend.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public User Create(User entity, long? createdById = null)
        {
           base.Create(entity, createdById);
            return entity;
        }

        public User Delete(long Id, long? createdById = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public User Update(User entity, long Id, long? createdById = null)
        {
            throw new NotImplementedException();
        }
    }
}
