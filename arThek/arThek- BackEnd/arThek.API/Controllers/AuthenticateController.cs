using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace arThek.API.Controllers
{
    [Route("arThek")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IBaseUserService _baseUserService;

        public AuthenticateController(IBaseUserService baseUserService)
        {
            _baseUserService = baseUserService;
        }

        [HttpPost("home/login")]
        [AllowAnonymous]

        public async Task<IActionResult> AuthenticateAsync(LoginBaseUserDto loginBaseUserDto)
        {
            return Ok(await _baseUserService.LoginAsync(loginBaseUserDto.EmailAddress, loginBaseUserDto.Password));
        }
    }
}
