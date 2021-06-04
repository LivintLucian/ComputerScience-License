using System;

namespace arThek.ServiceAbstraction.DTOs
{
    public class FollowDto
    {
        public Guid Id { get; set; }
        public Guid MenteeId { get; set; }
        public Guid MentorId { get; set; }
        public Boolean Unfollowed { get; set; }

    }
}
