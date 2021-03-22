using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using arThek.Entities.BaseEntities;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace arThek.API.Controllers
{
    [Route("arThek/register")]
    [ApiController]
    public class RegistrationSystemController : ControllerBase
    {
        private readonly IMentorService _mentorService;
        private readonly IMenteeService _menteeService;

        public RegistrationSystemController(IMentorService mentorService, IMenteeService menteeService)
        {
            _mentorService = mentorService;
            _menteeService = menteeService;
        }

        [HttpPost("UserType")]
        [AllowAnonymous]
        public async Task<IActionResult> DefineTypeOfUser(bool isMentee)
        {
            if (isMentee)
            {
                return Ok(await _menteeService.CreateAsync(new MenteeDto() { UserRole = UserRole.Mentee }));
            }
            else
            {
                return Ok(await _mentorService.CreateAsync(new MentorDto() { UserRole = UserRole.Mentor }));
            }
        }

        [HttpPut("Mentee/{id}")]
        public async Task<IActionResult> UpdateCreatedMentee(MenteeDto menteeDto, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _menteeService.UpdateAsync(menteeDto, id);

            return Ok();
        }

        [HttpPut("Mentor/{id}")]
        public async Task<IActionResult> UpdateCreatedMentor(MentorDto mentorDto, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mentorService.UpdateAsync(mentorDto, id);

            return Ok();
        }

        [HttpPut("Mentor/MentorType/{id}")]
        public async Task<IActionResult> DefineTypeOfMentor(MentorDto mentorDto, Guid id, bool isVolunteer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            mentorDto.IsVolunteer = 
                isVolunteer ? mentorDto.IsVolunteer = true : mentorDto.IsVolunteer = false;

            await _mentorService.UpdateAsync(mentorDto, id);

            return Ok();
        }

        [HttpPut("Mentor/Resume/{id}")]
        public async Task<IActionResult> UpdateMentorResume(MentorDto mentorDto, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mentorService.UpdateMentorResume(mentorDto, id);

            return Ok();
        }
    }
}

