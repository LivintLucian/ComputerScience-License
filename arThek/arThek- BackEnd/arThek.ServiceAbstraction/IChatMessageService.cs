using arThek.ServiceAbstraction.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface IChatMessageService
    {
        Task<ChatMessageDto> CreateAsync(ChatMessageDto chatMessageDto);
        Task<ChatMessageDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ChatMessageDto>> GetAllMessages();
    }
}
