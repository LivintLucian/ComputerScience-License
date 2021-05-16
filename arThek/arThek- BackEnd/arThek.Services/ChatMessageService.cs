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
    public class ChatMessageService : IChatMessageService
    {
        private readonly IMapper _mapper;
        private readonly IChatMessageRepository _chatMessageRepository;

        public ChatMessageService(IMapper mapper, IChatMessageRepository chatMessageRepository)
        {
            _mapper = mapper;
            _chatMessageRepository = chatMessageRepository;
        }

        public async Task<ChatMessageDto> CreateAsync(ChatMessageDto chatMessageDto)
        {
            var chatMessageDTO = _mapper.Map<ChatMessage>(chatMessageDto);
            var chatMessageAddedToDB = await _chatMessageRepository.CreateAsync(chatMessageDTO);

            return _mapper.Map<ChatMessageDto>(chatMessageAddedToDB);
        }

        public async Task<ChatMessageDto> GetByIdAsync(Guid id)
        {
            var chatMessage = await _chatMessageRepository.GetByIdAsync(id);

            if (chatMessage is null)
            {
                throw new NotFoundException("This message room doesn't exist!");
            }

            return _mapper.Map<ChatMessageDto>(chatMessage);
        }

        public async Task<IEnumerable<ChatMessageDto>> GetAllMessages()
        {
            var chatMessages = (await _chatMessageRepository.GetAll()).ToList();
            var chatMessageList = _mapper.Map<IEnumerable<ChatMessageDto>>(chatMessages);

            return chatMessageList;
        }
    }
}
