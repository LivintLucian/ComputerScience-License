using arThek.Entities.BaseEntities;
using System;

namespace arThek.Entities.Entities
{
    public class Notification : BaseEntity
    {
        public Guid MentorId { get; set; }
        public string Content { get; set; }
    }
}
