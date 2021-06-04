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
    public class NotificationService : INotificationService
    {
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(IMapper mapper, INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public async Task<NotificationDto> CreateAsync(NotificationDto notificationDto)
        {
            var notificationDTO = _mapper.Map<Notification>(notificationDto);
            var notificationAddedToDB = await _notificationRepository.CreateAsync(notificationDTO);

            return _mapper.Map<NotificationDto>(notificationAddedToDB);
        }

        public async Task<NotificationDto> GetByIdAsync(Guid id)
        {
            var notificationObj = await _notificationRepository.GetByIdAsync(id);

            if (notificationObj is null)
            {
                throw new NotFoundException("This follower doesn't exist!");
            }

            return _mapper.Map<NotificationDto>(notificationObj);
        }

        public async Task<IEnumerable<NotificationDto>> GetAllNotification()
        {
            var notifications = (await _notificationRepository.GetAll()).ToList();
            var notificationList = _mapper.Map<IEnumerable<NotificationDto>>(notifications);

            return notificationList;
        }

    }
}
