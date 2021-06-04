using System;

namespace arThek.API.Persistence
{
    public class MessageBetweenUsers
    {
        public string User { get; set; }
        public string Content { get; set; }
        public Guid MenteeId { get; set; }
        public Guid Mentor { get; set; }
        public string MessageDate { get; set; }
    }
}
