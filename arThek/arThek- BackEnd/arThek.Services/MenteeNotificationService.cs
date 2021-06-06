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
    public class MenteeNotificationService : IMenteeNotificationService
    {
        private readonly IMapper _mapper;
        private readonly IMenteeNotificationRepository _menteeNotififcationRepository;

        public MenteeNotificationService(IMapper mapper, IMenteeNotificationRepository menteeNotififcationRepository)
        {
            _mapper = mapper;
            _menteeNotififcationRepository = menteeNotififcationRepository;
        }

        public async Task<MenteeNotificationDto> CreateAsync(MenteeNotificationDto notificationDto)
        {
            var notificationDTO = _mapper.Map<MenteeNotification>(notificationDto);
            var notificationAddedToDB = await _menteeNotififcationRepository.CreateAsync(notificationDTO);

            return _mapper.Map<MenteeNotificationDto>(notificationAddedToDB);
        }

        public async Task<MenteeNotificationDto> GetByIdAsync(Guid id)
        {
            var notificationObj = await _menteeNotififcationRepository.GetByIdAsync(id);

            if (notificationObj is null)
            {
                throw new NotFoundException("This follower doesn't exist!");
            }

            return _mapper.Map<MenteeNotificationDto>(notificationObj);
        }

        public async Task<IEnumerable<MenteeNotificationDto>> GetAllNotification()
        {
            var notifications = (await _menteeNotififcationRepository.GetAll()).ToList();
            var notificationList = _mapper.Map<IEnumerable<MenteeNotificationDto>>(notifications);

            return notificationList;
        }

        public async Task<MenteeNotificationDto> UpdateAsync(MenteeNotificationDto notification)
        {
            MenteeNotification not = (await _menteeNotififcationRepository.GetAll()).ToList()
                                        .Where(x => x.MenteeId.CompareTo(notification.MenteeId) == 0
                                        && x.NotificationId.CompareTo(notification.NotificationId) == 0)
                                        .FirstOrDefault();

            not.Visualised = true;

            var result = await _menteeNotififcationRepository.UpdateAsync(not);
            return _mapper.Map<MenteeNotificationDto>(result);
        }
    }
}
