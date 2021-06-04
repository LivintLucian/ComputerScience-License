using arThek.Entities.BaseEntities;
using System;

namespace arThek.Entities.Entities
{
    public class MenteeNotification : BaseEntity
    {
        public Guid MenteeId { get; set; }
        public Guid NotificationId { get; set; }
        public Boolean Visualised { get; set; }
    }
}
