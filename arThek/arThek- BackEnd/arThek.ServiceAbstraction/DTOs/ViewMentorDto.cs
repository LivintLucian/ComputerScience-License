using arThek.Entities.BaseEntities;

namespace arThek.ServiceAbstraction.DTOs
{
    public class ViewMentorDto : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string IsVolunteer { get; set; }
    }
}
