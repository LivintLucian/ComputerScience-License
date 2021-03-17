﻿using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arThek.API.Controllers
{
    [Route("arThek/[controller]")]
    [ApiController]
    public class BaseUserController : ControllerBase
    {
        private readonly IBaseUserService _baseUserService;

        public BaseUserController(IBaseUserService baseUserService)
        {
            _baseUserService = baseUserService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]

        public async Task<IActionResult> AuthenticateAsync(LoginBaseUserDto loginBaseUserDto)
        {
            return Ok(await _baseUserService.LoginAsync(loginBaseUserDto.EmailAddress));
        }
    }
}
