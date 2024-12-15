using Core.Dtos.LoginDtos;
using Core.Dtos.UserDtos;
using Core.Interfaces.Errors;
using Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public abstract IResult<User> loginUser(LoginDto dto);
    }
}
