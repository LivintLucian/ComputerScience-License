using arThek.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.Entities.Entities
{
    public class Follow : BaseEntity
    {
        public Guid MenteeId { get; set; }
        public Guid MentorId { get; set; }
        public Boolean Unfollowed { get; set; }
    }
}
