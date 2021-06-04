using System;

namespace arThek.ServiceAbstraction.DTOs
{
    public class MenteeNotificationDto
    {
        public Guid MenteeId { get; set; }
        public Guid NotificationId { get; set; }
        public Boolean Visualised { get; set; }
    }
}
