using arThek.Entities.Entities;
using arThek.ServiceAbstraction.InterfaceDTOs;

namespace arThek.Services.Filtering.Conditions
{
    public class IsVolunteerCondition : IMentorConditions
    {
        private bool _isVolunteer;
        public void AddFilterOptions(IFilterMentors options)
        {
            _isVolunteer = options.IsVolunteer;
        }

        public bool IsSatisfied(Mentor mentor)
        {
            return _isVolunteer == mentor.IsVolunteer;
        }
    }
}
