using arThek.ServiceAbstraction.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface IChatMessengerBetweenUsersService
    {
        Task<ChatMessengerBetweenUsersDto> CreateAsync(ChatMessengerBetweenUsersDto chatMessengerBetweenUsersDto);
        Task<ChatMessengerBetweenUsersDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ChatMessengerBetweenUsersDto>> GetAllMessages();
    }
}
