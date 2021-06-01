using arThek.Entities.BaseEntities;
using Microsoft.AspNetCore.Http;

namespace arThek.ServiceAbstraction.DTOs
{
    public class ViewMentorDto : BaseEntity
    {
        public string UserName { get; set; }
        public string Domain { get; set; }
        public string IsVolunteer { get; set; }
    }
}
