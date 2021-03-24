using arThek.Entities.BaseEntities;
using System;
using System.Collections.Generic;

namespace arThek.Entities.Entities
{
    public class Mentor : BaseUser
    {
        public string AboutMe { get; set; }
        public string Experience { get; set; }
        public byte[] Resume { get; set; }
        public bool IsVolunteer { get; set; }
        public bool IsDeleted { get; set; }
        public MentorshipPackage Basic { get; set; }
        public MentorshipPackage Standard { get; set; }
        public MentorshipPackage Premium { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
