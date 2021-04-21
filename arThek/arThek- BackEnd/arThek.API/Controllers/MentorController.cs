using System;
using System.Threading.Tasks;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace arThek.API.Controllers
{
    [ApiController]
    [Route("arThek/[controller]")]
    public class MentorController : ControllerBase
    {
        private readonly IMentorService _mentorService;

        public MentorController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        #region Create | Update | Delete

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] MentorDto mentorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var mentorCreated = await _mentorService.CreateAsync(mentorDto);

            return CreatedAtAction(nameof(GetById), new { id = mentorCreated.Id }, mentorCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(MentorDto mentorDto, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mentorService.UpdateAsync(mentorDto, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mentorService.DeleteAsync(id);

            return NoContent();
        }

        #endregion

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllMentorsAsync()
        {
            var mentorList = await _mentorService.GetAllMentors();

            return Ok(mentorList);
        }

        [HttpGet("profile/{id}")]
        public async Task<ActionResult<MentorDto>> GetById(Guid id)
        {
            return await _mentorService.GetByIdAsync(id);
        }

        [HttpGet("profile/lastMentor")]
        public async Task<ActionResult<MentorProfileUpdateDto>> GetLastMentorAdded()
        {
            var lastMentor = await _mentorService.GetLastMentorAsync();

            return lastMentor;
        }

        [HttpPost("filter")]
        public async Task<ActionResult<ViewMentorDto>> Get(
            [FromBody] MentorParametersDto mentorParameters)
        {
            var allMentorsInPage = await _mentorService.GetFilteredTrainings(mentorParameters);

            return Ok(allMentorsInPage);
        }
    }
}
