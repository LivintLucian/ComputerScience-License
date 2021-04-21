using arThek.ServiceAbstraction.InterfaceDTOs;

namespace arThek.ServiceAbstraction.DTOs
{
    public class FilterMentorsDto : IFilterMentors
    {
        public string UserName { get; set; }
        public string Domain { get; set; }
        public bool IsVolunteer { get; set; }
    }
}   
