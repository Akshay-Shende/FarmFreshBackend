using Core.Dtos.UserDtos;
using Core.Interfaces;
using Core.Models.Users;
using FarmFreshBackend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmFreshBackend.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IRepository<User> _userRepository;
        public UserController(Repository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id:long}")]
        public IActionResult Get([FromRoute] long id)
        {
          var result =  _userRepository.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Index() {
           var result =  _userRepository.FindAll(e => e.DeletedOn == null);
            return Ok(result.ResultObject.ToList());
        }

        [HttpPost]
        public IActionResult Post(UserDto userDto)
        {
            User user = new User()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };
            var result = _userRepository.Create(user, 1);

            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete ([FromRoute] long id)
        {
            var result = _userRepository.Delete(id, 1);
            return Ok(result);
        }
    }
}
