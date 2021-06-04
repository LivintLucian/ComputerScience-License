using arThek.Entities.BaseEntities;
using System;

namespace arThek.Entities.Entities
{
    public class ChatMessengerBetweenUsers : BaseEntity
    {
        public string User { get; set; }
        public string Content { get; set; }
        public Guid MenteeId { get; set; }
        public Guid Mentor { get; set; }
        public string MessageDate { get; set; }
    }
}
