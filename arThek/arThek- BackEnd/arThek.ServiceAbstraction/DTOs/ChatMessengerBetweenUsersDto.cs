using System;

namespace arThek.ServiceAbstraction.DTOs
{
    public class ChatMessengerBetweenUsersDto
    {
        public Guid Id { get; set; }
        public Guid Mentor { get; set; }
        public Guid MenteeId { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
        public string MessageDate { get; set; }
    }
}
