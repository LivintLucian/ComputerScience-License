using arThek.Entities.BaseEntities;

namespace arThek.ServiceAbstraction.DTOs
{
    public class BaseUserDto : BaseEntity 
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Category { get; set; }
        public UserRole UserType { get; set; }
    }
}
