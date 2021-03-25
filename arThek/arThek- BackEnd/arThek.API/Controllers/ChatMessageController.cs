using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace arThek.API.Controllers
{
    [Route("arThek/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatMessageService _chatMessageService;
        public ChatMessageController(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
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
