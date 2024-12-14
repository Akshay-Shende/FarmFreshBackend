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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("get value");
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
    }
}
