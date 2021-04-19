using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using arThek.Entities.BaseEntities;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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

        [HttpPost("Mentee")]
        public async Task<IActionResult> Create([FromForm] CreateMenteeDto createMenteeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var menteeCreated = await _menteeService.CreateAsync(createMenteeDto);

            return CreatedAtAction(nameof(GetById), new { id = menteeCreated.Id }, menteeCreated);
        }

        [HttpGet("Mentee/{id}")]
        public async Task<ActionResult<MenteeDto>> GetById(Guid id)
        {
            return await _menteeService.GetByIdAsync(id);
        }

        [HttpPut("Mentee")]
        public async Task<IActionResult> UpdateCreatedMentee([FromForm] MenteeDto menteeDto, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //var lastCreatedMentee = _menteeService.GetLastMenteeCreated();
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

        [HttpPut("Mentor/MentorType")]
        public async Task<IActionResult> DefineTypeOfMentor(bool isVolunteer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mentorService.UpdateLastMentorAdded(isVolunteer);

            return Ok();
        }

        [HttpPut("Mentor/Additional-Data")]
        public async Task<IActionResult> UpdateMentorResume([FromForm] MentorAdditionalDataDto mentorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mentorService.UpdateMentorResume(mentorDto);

            return Ok();
        }

        [HttpPut("Mentor/Mentor-Profile")]
        public async Task<IActionResult> UpdateMentorProfile([FromForm] MentorProfileUpdateDto mentorProfileUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mentorService.UpdateMentorProfile(mentorProfileUpdateDto);

            return Ok();
        }
    }
}

