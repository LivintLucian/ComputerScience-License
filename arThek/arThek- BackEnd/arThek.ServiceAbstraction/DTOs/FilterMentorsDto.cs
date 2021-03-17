using arThek.ServiceAbstraction.InterfaceDTOs;

namespace arThek.ServiceAbstraction.DTOs
{
    public class FilterMentorsDto : IFilterMentors
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsVolunteer { get; set; }
    }
}   
