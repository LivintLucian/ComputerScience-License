using arThek.Entities.BaseEntities;
using System;

namespace arThek.Entities.Entities
{
    public class ChatMessage : BaseEntity
    {
        public string Content { get; set; }
        public Guid MentorId { get; set; }
        public Guid MenteeId { get; set; }
    }
}
