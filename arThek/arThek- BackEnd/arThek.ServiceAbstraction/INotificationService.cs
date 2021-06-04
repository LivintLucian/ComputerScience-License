using arThek.ServiceAbstraction.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arThek.ServiceAbstraction
{
    public interface INotificationService
    {
        Task<NotificationDto> CreateAsync(NotificationDto followDto);
        Task<NotificationDto> GetByIdAsync(Guid id);
        Task<IEnumerable<NotificationDto>> GetAllNotification();
    }
}
