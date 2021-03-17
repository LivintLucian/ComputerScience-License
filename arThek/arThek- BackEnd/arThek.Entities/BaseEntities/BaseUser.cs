using arThek.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arThek.Entities.BaseEntities
{
    public abstract class BaseUser : BaseEntity
    {
        public virtual UserRole UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Category { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] ProfileImage { get; set; }
        public Guid ChatMessageId { get; set; }
    }
}
