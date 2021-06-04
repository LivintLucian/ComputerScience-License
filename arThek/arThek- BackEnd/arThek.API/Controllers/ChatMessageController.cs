using arThek.API.Persistence;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using arThek.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace arThek.API.Controllers
{
    [Produces("application/json")]
    [Route("arThek/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatMessageService _chatMessageService;
        private readonly IHubContext<SignalRHub> _hubContext;
        private readonly IChatMessengerBetweenUsersService _chatMessengerBetweenUsersService;
        private readonly IMenteeService _menteeService;
        private readonly IMentorService _mentorService;

        public ChatMessageController(IChatMessageService chatMessageService, IHubContext<SignalRHub> hubContext, IChatMessengerBetweenUsersService chatMessengerBetweenUsersService, IMentorService mentorService, IMenteeService menteeService)
        {
            _chatMessageService = chatMessageService;
            _hubContext = hubContext;
            _chatMessengerBetweenUsersService = chatMessengerBetweenUsersService;
            _menteeService = menteeService;
            _mentorService = mentorService;
        }

        [Route("public-chat")]              
        [HttpPost]
        public async Task<IActionResult> SendRequest([FromBody] Message msg)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveOne", msg.User, msg.MsgText, msg.Category, msg.UserType, msg.MessageDate);
            var chatMessageDto = new ChatMessageDto
            {
                User = msg.User,
                MsgText = msg.MsgText,
                Category = msg.Category,
                UserType = msg.UserType,
                MessageDate = msg.MessageDate
            };
            await _chatMessageService.CreateAsync(chatMessageDto);
            return Ok();
        }

        [Route("send-message")]
        [HttpPost]
        public async Task<IActionResult> SendRequest2([FromBody] MessageBetweenUsers msg)
        {
            //await _hubContext.Clients.All.SendAsync("ReceiveTwo", msg.User, msg.MsgText, msg.Category, msg.UserType, msg.MessageDate);
            var chatMessageDto = new ChatMessengerBetweenUsersDto
            {
                User = msg.User,
                Content = msg.Content,
                MenteeId = msg.MenteeId,
                Mentor = msg.Mentor,
                MessageDate = msg.MessageDate
            };
            await _chatMessengerBetweenUsersService.CreateAsync(chatMessageDto);
            return Ok();
        }

        public async Task<IActionResult> Create(ChatMessageDto chatMessageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var chatMessageCreated = await _chatMessageService.CreateAsync(chatMessageDto);

            return CreatedAtAction(nameof(GetById), new { id = chatMessageCreated.Id }, chatMessageCreated);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatMessageDto>> GetById(Guid id)
        {
            return await _chatMessageService.GetByIdAsync(id);
        }

        [HttpGet("public-chat")]
        public async Task<IActionResult> GetAllMessagesAsync()
        {
            var chatMessagesList = await _chatMessageService.GetAllMessages();

            return Ok(chatMessagesList);
        }

        public async Task<IActionResult> SendMessageBetweenUsers(ChatMessengerBetweenUsersDto chatMessageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var chatMessageCreated = await _chatMessengerBetweenUsersService.CreateAsync(chatMessageDto);

            return CreatedAtAction(nameof(GetById), new { id = chatMessageCreated.Id }, chatMessageCreated);
        }

        [HttpGet("get-message")]
        public async Task<ActionResult<ChatMessengerBetweenUsersDto>> GetMessageBetweenUsers(Guid id)
        {
            return await _chatMessengerBetweenUsersService.GetByIdAsync(id);
        }

        [HttpGet("get-message/all")]
        public async Task<IActionResult> GetAllArticlesAsync([FromQuery]string mentorId, [FromQuery]string menteeId)
        {
            var articlesList = await _chatMessengerBetweenUsersService.GetAllMessages();
            var data = articlesList.Where(x => x.MenteeId.ToString().ToUpper() == menteeId.ToUpper() && x.Mentor.ToString().ToUpper() == mentorId.ToUpper()).Select(x => x);

            return Ok(data);
        }

        [HttpGet("get-chat-users")]
        public async Task<IActionResult> GetChatUsersFor([FromQuery] string userId, [FromQuery] int userType)
        {
            if(userType == 0)
            {
                var articleList = await _chatMessengerBetweenUsersService.GetAllMessages();
                List<string> data = articleList.Where(x => x.MenteeId.ToString().ToUpper() == userId.ToUpper()).Distinct().Select(x => x.Mentor.ToString().ToUpper()).ToList();
                var result = (await _mentorService.GetAllMentors()).Where(x => data.Contains(x.Id.ToString().ToUpper())).Select(x => x).ToList();
                for(int i = 0; i < result.Count; i++)
                {
                    result[i].Resume = null;
                    //result[i].ProfileImagePath = null;
                    result[i].Password = "";
                    result[i].ConfirmPassword = "";
                }
                return Ok(result);
            }
            else
            {
                var articleList = await _chatMessengerBetweenUsersService.GetAllMessages();
                List<string> data = articleList.Where(x => x.Mentor.ToString().ToUpper() == userId.ToUpper()).Distinct().Select(x => x.MenteeId.ToString().ToUpper()).ToList();
                var result = (await _menteeService.GetAllMentees()).Where(x => data.Contains(x.Id.ToString().ToUpper())).Select(x => x).ToList();
                for(int i = 0; i < result.Count; i++)
                {
                    //result[i].ProfileImagePath = null;
                    result[i].Password = "";
                    result[i].ConfirmPassword = "";
                }
                return Ok(result);
            }
        }
    }
}
