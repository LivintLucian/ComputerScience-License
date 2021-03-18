using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace arThek.API.Controllers
{
    [Route("arThek/home")]
    [ApiController]
    public class BaseUserController : ControllerBase
    {
        private readonly IBaseUserService _baseUserService;

        public BaseUserController(IBaseUserService baseUserService)
        {
            _baseUserService = baseUserService;
        }

        [HttpPost("login")]
        [AllowAnonymous]

        public async Task<IActionResult> AuthenticateAsync(LoginBaseUserDto loginBaseUserDto)
        {
            return Ok(await _baseUserService.LoginAsync(loginBaseUserDto.EmailAddress, loginBaseUserDto.Password));
        }
    }
}
