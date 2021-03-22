using arThek.Entities.BaseEntities;
using Microsoft.AspNetCore.Http;

namespace arThek.ServiceAbstraction.DTOs
{
    public class CreateUpdateMentorDto : BaseUser
    {
        public IFormFile Resume { get; set; }
        public bool IsVolunteer { get; set; }
    }
}
