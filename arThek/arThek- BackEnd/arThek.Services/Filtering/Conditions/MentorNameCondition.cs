using arThek.Entities.Entities;
using arThek.ServiceAbstraction.InterfaceDTOs;

namespace arThek.Services.Filtering.Conditions
{
    public class MentorNameCondition : IMentorConditions
    {
        private string _mentorName;
        public void AddFilterOptions(IFilterMentors options)
        {
            _mentorName = options.UserName;
        }

        public bool IsSatisfied(Mentor mentor)
        {
            return _mentorName == mentor.UserName;
        }
    }
}
