using arThek.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace arThek.Entities.Entities
{
    public class GuestUser : BaseEntity
    {
        public Mentor Mentor { get; set; }
        public Mentee Mentee { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Category { get; set; }
        public UserRole UserType { get; set; }
    }
}
