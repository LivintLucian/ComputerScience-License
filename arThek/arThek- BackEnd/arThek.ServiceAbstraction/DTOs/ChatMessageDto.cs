using arThek.Entities.BaseEntities;
using System;

namespace arThek.ServiceAbstraction.DTOs
{
    public class ChatMessageDto : BaseEntity
    {
        public string Content { get; set; }
        public Guid MentorId { get; set; }
        public Guid MenteeId { get; set; }
    }
}
