using arThek.ServiceAbstraction.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface IMenteeNotificationService
    {
        Task<MenteeNotificationDto> CreateAsync(MenteeNotificationDto notificationDto);

        Task<MenteeNotificationDto> GetByIdAsync(Guid id);

        Task<IEnumerable<MenteeNotificationDto>> GetAllNotification();

        Task<MenteeNotificationDto> UpdateAsync(MenteeNotificationDto notificationDto);
    }
}
