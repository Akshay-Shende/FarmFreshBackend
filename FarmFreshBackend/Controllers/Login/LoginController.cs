using Core.Dtos.LoginDtos;
using Core.Interfaces.Repositories;
using FarmFreshBackend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmFreshBackend.Controllers.Login
{
    [Route("api/v1/authentication")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IUserRepository _userGenRepository;
        public LoginController( UserRepository userGenRepository)
        {
            _userGenRepository = userGenRepository;

        }
        [HttpPost]
        public IActionResult Post(LoginDto loginDto)
        {
           var loginResult = _userGenRepository.loginUser(loginDto);

            return Ok(loginResult);
        }
    }
}
