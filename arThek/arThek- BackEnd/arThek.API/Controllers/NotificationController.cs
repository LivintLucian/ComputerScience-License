using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arThek.API.Controllers
{
    [Route("arThek/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IFollowService _followService;
        private readonly INotificationService _notificationService;
        private readonly IMenteeNotificationService _menteeNotificationService;
        private readonly IMapper _mapper;

        public NotificationController(IFollowService followService, INotificationService notificationService, IMenteeNotificationService menteeNotificationsService, IMapper mapper)
        {
            _followService = followService;
            _notificationService = notificationService;
            _menteeNotificationService = menteeNotificationsService;
            _mapper = mapper;
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

        [HttpGet("notifications")]
        public async Task<IActionResult> GetAllNotifications(Guid menteeId)
        {
            var menteeNotifications = (await _menteeNotificationService.GetAllNotification()).ToList()
                                        .Where(x => x.MenteeId.CompareTo(menteeId) == 0 && x.Visualised == false).Select(x => x.NotificationId);
            var notifications = (await _notificationService.GetAllNotification()).ToList()
                                    .Where(x => menteeNotifications.Contains(x.Id)).Select(x => x);
            //return Ok(notifications.Where(x => x.))
            var result = _mapper.Map<List<NotificationDto>>(notifications);
            return Ok(result);
        }

        [HttpPut("notifications/view")]
        public async Task<IActionResult> MarkAsView(MenteeNotificationDto notification)
        {
            var result = await _menteeNotificationService.UpdateAsync(notification);
            return Ok(result);
        }

        [HttpPost("notifications")]
        public async Task<IActionResult> AddNotification([FromForm]NotificationDto notification)
        {
            var not = await _notificationService.CreateAsync(notification);
            var followwers = (await _followService.GetAllFollowers()).ToList()
                                .Where(x => x.MentorId.CompareTo(not.MentorId) == 0 && x.Unfollowed == false).Distinct()
                                .Select(x => x.MenteeId).ToList();
            var result = new List<MenteeNotificationDto>();
            for(int follower = 0; follower<followwers.Count(); ++follower)
            {
                var tempDto = new MenteeNotificationDto();
                tempDto.MenteeId = followwers[follower];
                tempDto.NotificationId = not.Id;
                tempDto.Visualised = false;
                result.Add(await _menteeNotificationService.CreateAsync(tempDto));
            }
            //followwers.ForEach(async menteeId =>
            //{
            //    var tempDto = new MenteeNotificationDto();
            //    tempDto.MenteeId = menteeId;
            //    tempDto.NotificationId = not.Id;
            //    tempDto.Visualised = false;
            //    result.Add(await _menteeNotificationService.CreateAsync(tempDto));
            //});
            
            return Ok(result);
        }

        [HttpPut("unfollow")]
        public async Task<ActionResult> Delete(Guid mentorId, Guid menteeId)
        {
            await _followService.DeleteAsync(mentorId, menteeId);

            return NoContent();
        }
    }
}
