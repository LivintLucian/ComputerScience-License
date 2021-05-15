using arThek.API.Persistence;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using arThek.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace arThek.API.Controllers
{
    [Produces("application/json")]
    [Route("arThek/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatMessageService _chatMessageService;
        private readonly IHubContext<SignalRHub> _hubContext;
        public ChatMessageController(IChatMessageService chatMessageService, IHubContext<SignalRHub> hubContext)
        {
            _chatMessageService = chatMessageService;
            _hubContext = hubContext;
        }

        [Route("public-chat")]              
        [HttpPost]
        public async Task<IActionResult> SendRequest([FromBody] Message msg)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveOne", msg.User, msg.MsgText, msg.Category, msg.UserType, msg.MessageDate);
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
    }
}
