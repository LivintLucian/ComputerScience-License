using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace arThek.API.Controllers
{
    [Route("arThek/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IFollowService _followService;

        public NotificationController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpPost("follow")]
        public async Task<IActionResult> Create(FollowDto followDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var articleCreated = await _followService.CreateAsync(followDto);

            return CreatedAtAction(nameof(GetById), new { id = articleCreated.Id }, articleCreated);
        }

        [HttpGet("follow")]
        public async Task<ActionResult<FollowDto>> GetById(Guid id)
        {
            return await _followService.GetByIdAsync(id);
        }

        [HttpGet("follow/getAll")]
        public async Task<IActionResult> GetAllFollowersAsync()
        {
            var articlesList = await _followService.GetAllFollowers();

            return Ok(articlesList);
        }

        [HttpGet("follow/mentee-following")]
        public async Task<IActionResult> GetAllMenteeFollowingAsync(Guid menteeId)
        {
            var articlesList = await _followService.GetMenteeFollowing(menteeId);

            return Ok(articlesList);
        }

        [HttpPut("unfollow")]
        public async Task<ActionResult> Delete(Guid mentorId, Guid menteeId)
        {
            await _followService.DeleteAsync(mentorId, menteeId);

            return NoContent();
        }
    }
}
