using System;

namespace arThek.Entities.BaseEntities
{
    public abstract class BaseUser : BaseEntity
    {
        public virtual UserRole UserRole { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Domain { get; set; }
        public string ProfileImagePath { get; set; }
        public Guid ChatMessageId { get; set; }
        public DateTime UserCreationDate { get; set; }
    }
}
