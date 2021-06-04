using Amazon.SimpleNotificationService.Model;
using arThek.Entities.Entities;
using arThek.Entities.RepositoryInterfaces;
using arThek.ServiceAbstraction;
using arThek.ServiceAbstraction.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class ChatMessengerBetweenUsersService : IChatMessengerBetweenUsersService
    {
        private readonly IMapper _mapper;
        private readonly IChatMessengerBetweenUsersRepository _chatMessageBetweenUsersRepository;
        public ChatMessengerBetweenUsersService(IMapper mapper, IChatMessengerBetweenUsersRepository chatMessengerBetweenUsersRepository)
        {
            _mapper = mapper;
            _chatMessageBetweenUsersRepository = chatMessengerBetweenUsersRepository;
        }

        public async Task<ChatMessengerBetweenUsersDto> CreateAsync(ChatMessengerBetweenUsersDto chatMessengerBetweenUsersDto)
        {
            var chatMessengerBetweenUsersDTO = _mapper.Map<ChatMessengerBetweenUsers>(chatMessengerBetweenUsersDto);
            var chatMessengerBetweenUsersAddedToDB = await _chatMessageBetweenUsersRepository.CreateAsync(chatMessengerBetweenUsersDTO);

            return _mapper.Map<ChatMessengerBetweenUsersDto>(chatMessengerBetweenUsersAddedToDB);
        }

        public async Task<ChatMessengerBetweenUsersDto> GetByIdAsync(Guid id)
        {
            var chatMessengerBetweenUsers = await _chatMessageBetweenUsersRepository.GetByIdAsync(id);

            if (chatMessengerBetweenUsers is null)
            {
                throw new NotFoundException("This rating doesn't exist!");
            }

            return _mapper.Map<ChatMessengerBetweenUsersDto>(chatMessengerBetweenUsers);
        }

        public async Task<IEnumerable<ChatMessengerBetweenUsersDto>> GetAllMessages()
        {
            var chatMessengerBetweenUsers = (await _chatMessageBetweenUsersRepository.GetAll()).ToList();
            var chatMessengerBetweenUsersList = _mapper.Map<IEnumerable<ChatMessengerBetweenUsersDto>>(chatMessengerBetweenUsers);

            return chatMessengerBetweenUsersList;
        }
    }
}
