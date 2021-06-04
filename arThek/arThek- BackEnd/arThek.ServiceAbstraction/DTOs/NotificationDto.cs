using System;

namespace arThek.ServiceAbstraction.DTOs
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public Guid MentorId { get; set; }
        public string Content { get; set; }
    }
}
