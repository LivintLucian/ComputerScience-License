using arThek.Entities.BaseEntities;
using System;

namespace arThek.ServiceAbstraction.DTOs
{
    public class CreateMenteeDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Domain { get; set; }
        public string ProfileImagePath { get; set; }
        public DateTime UserCreationDate { get; set; }
    }
}
