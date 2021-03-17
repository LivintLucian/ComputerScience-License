using System;
using System.Threading.Tasks;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
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
        public async Task<IActionResult> Create(MentorDto mentorDto)
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

        [HttpGet]
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

        [HttpPost("filter")]
        public async Task<ActionResult<ViewMentorDto>> Get(
            [FromBody] MentorParametersDto trainingParameters)
        {
            var allMentorsInPage = await _mentorService.GetFilteredTrainings(trainingParameters);

            return Ok(allMentorsInPage);
        }
    }
}
